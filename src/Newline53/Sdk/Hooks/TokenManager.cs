using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newline53.Sdk.Models.Requests;
using Newline53.Sdk.Utils;

namespace Newline53.Sdk.Utils
{
    public class TokenInfo
    {
        public string Token { get; set; } = "";
        public DateTime ExpiresAt { get; set; }
    }

    public class TokenManagerConfig
    {
        public string ProgramUID { get; set; } = "";
        public string HmacKey { get; set; } = "";
        public int TokenExpiryBuffer { get; set; }
        public string ServerURL { get; set; } = "";
        public string UserAgent { get; set; } = "";
        public INewlineSDKHttpClient? Client { get; set; }
    }

    public class TokenManager
    {
        private TokenInfo TokenInfo { get; set; }
        private TokenManagerConfig Config { get; set; }
        private Task<string>? refreshTask;
        private readonly object refreshLock = new object();

        public TokenManager(TokenManagerConfig config)
        {
            this.Config = config;
            this.TokenInfo = new TokenInfo();
        }

        public async Task<string> GetValidTokenAsync()
        {
            if (IsTokenValid())
            {
                return TokenInfo.Token;
            }

            Task<string> currentRefreshTask;
            lock (refreshLock)
            {
                if (refreshTask != null && !refreshTask.IsCompleted)
                {
                    currentRefreshTask = refreshTask;
                }
                else
                {
                    refreshTask = RefreshTokenAsync();
                    currentRefreshTask = refreshTask;
                }
            }
            try
            {
                var token = await currentRefreshTask;
                return token;
            }
            finally
            {
                lock (refreshLock)
                {
                    if (refreshTask != null && refreshTask.IsCompleted)
                        refreshTask = null;
                }
            }
        }

        private bool IsTokenValid()
        {
            if (TokenInfo == null || string.IsNullOrEmpty(TokenInfo.Token))
            {
                return false;
            }
            DateTime now = DateTime.UtcNow;
            return TokenInfo.ExpiresAt > now.AddSeconds(Config.TokenExpiryBuffer);
        }

        private async Task<string> RefreshTokenAsync()
        {
            string refreshToken = GenerateRefreshToken();
            var response = await CallAuthEndpoint(refreshToken);
            DateTime expires = DateTime.UtcNow.AddSeconds(8 * 60 * 60); // Tokens are valid for 8 hours
            if (response?.Token == null)
            {
                throw new InvalidOperationException("No access token returned from /auth");
            }
            this.TokenInfo = new TokenInfo
            {
                Token = response.Token,
                ExpiresAt = expires
            };
            return response.Token;
        }

        public string GenerateRefreshToken()
        {
            var header = Base64UrlEncode(JsonSerializer.Serialize(new { alg = "HS512", typ = "JWT" }));
            var payload = Base64UrlEncode(JsonSerializer.Serialize(new { sub = Config.ProgramUID, iat = DateTimeOffset.UtcNow.ToUnixTimeSeconds() }));
            var message = $"{header}.{payload}";

            using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(Config.HmacKey));
            var signature = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
            return $"{message}.{Base64UrlEncode(signature)}";
        }

        private async Task<GenerateAuthTokenResponseBody> CallAuthEndpoint(string refreshToken)
        {
            var traceId = Guid.NewGuid().ToString();
            bool isLocalhost = Config.ServerURL.Contains("localhost", StringComparison.OrdinalIgnoreCase);
            try
            {
                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Post, $"{Config.ServerURL}/auth");
                request.Headers.Add("x-trace-id", traceId);
                request.Headers.Add("Authorization", refreshToken);
                request.Headers.Add("Accept", "application/json");
                if (!string.IsNullOrEmpty(Config.UserAgent))
                {
                    request.Headers.Add("user-agent", Config.UserAgent);
                }

                request.Content = new System.Net.Http.StringContent("{}", System.Text.Encoding.UTF8, "application/json");
                System.Net.Http.HttpResponseMessage response;

                if (isLocalhost)
                {
                    // Test mockserver routes /auth only for the generateAuthToken test name.
                    request.Headers.Remove("x-speakeasy-test-name");
                    request.Headers.Add("x-speakeasy-test-name", "generateAuthToken");
                    request.Headers.Remove("x-speakeasy-test-instance-id");
                    request.Headers.Add("x-speakeasy-test-instance-id", Guid.NewGuid().ToString("N"));

                    // Bypass test wrapper client to prevent it appending a second test name header.
                    using var directClient = new System.Net.Http.HttpClient();
                    response = await directClient.SendAsync(request);
                }
                else
                {
                    var client = Config.Client ?? new NewlineSDKHttpClient();
                    response = await client.SendAsync(request);
                }
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new InvalidOperationException($"Failed to refresh token: {(int)response.StatusCode} {error}");
                }
                var json = await response.Content.ReadAsStringAsync();
                var result = System.Text.Json.JsonSerializer.Deserialize<GenerateAuthTokenResponseBody>(
                    json,
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
                return result ?? throw new InvalidOperationException("Failed to deserialize /auth response");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error calling /auth endpoint: {ex.Message}", ex);
            }
        }

        public void SetToken(string token, DateTime? expiresAt = null)
        {
            this.TokenInfo = new TokenInfo
            {
                Token = token,
                ExpiresAt = expiresAt ?? DateTime.UtcNow.AddSeconds(8 * 60 * 60)
            };
        }

        public void ClearToken()
        {
            this.TokenInfo = new TokenInfo();
        }

        private static string Base64UrlEncode(string input) =>
            Base64UrlEncode(Encoding.UTF8.GetBytes(input));

        private static string Base64UrlEncode(byte[] input) =>
            Convert.ToBase64String(input)
                .TrimEnd('=')
                .Replace('+', '-')
                .Replace('/', '_');
    }
}