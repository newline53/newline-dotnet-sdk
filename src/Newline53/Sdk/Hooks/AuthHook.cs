using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newline53.Sdk.Utils;

namespace Newline53.Sdk.Hooks
{
    public class AuthHook : IBeforeRequestHook
    {
        private readonly string[] skipOperationsIDs;
        private readonly string AUTH_OPERATION = "generateAuthToken";
        public AuthHook(string[]? skipOperationsIDs = null)
        {
            this.skipOperationsIDs = skipOperationsIDs ?? new[] { "post_/auth", "get_/up" };
        }

        public async Task<HttpRequestMessage> BeforeRequestAsync(BeforeRequestContext hookCtx, HttpRequestMessage request)
        {
            // Add x-trace- header
            request.Headers.Add("x-trace-id", Guid.NewGuid().ToString());
            if (skipOperationsIDs != null && skipOperationsIDs.Contains(hookCtx.OperationID))
            {
                return request;
            }
            var securityObj = hookCtx.SecuritySource?.Invoke();
            if (securityObj is Newline53.Sdk.Models.Components.Security security &&
                !string.IsNullOrEmpty(security.ProgramUid) &&
                !string.IsNullOrEmpty(security.HmacKey))
            {
                var config = new TokenManagerConfig
                {
                    ProgramUID = security.ProgramUid,
                    HmacKey = security.HmacKey,
                    TokenExpiryBuffer = 60,
                    ServerURL = hookCtx.BaseURL,
                    UserAgent = hookCtx.SDKConfiguration.UserAgent,
                    Client = hookCtx.SDKConfiguration.Client
                };
                var tokenManager = new TokenManager(config);
                string token = AUTH_OPERATION == hookCtx.OperationID ? tokenManager.GenerateRefreshToken() : await tokenManager.GetValidTokenAsync();
                request.Headers.Add("Authorization", token);
            }
            return request;
        }
    }
}