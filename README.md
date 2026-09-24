# Newline .NET SDK

Developer-friendly and type-safe .NET SDK built to leverage the Newline Platform APIs.

<!-- No Summary [summary] -->

<!-- Start Table of Contents [toc] -->
## Table of Contents
<!-- $toc-max-depth=2 -->
* [Newline .NET SDK](#newline-net-sdk)
  * [SDK Installation](#sdk-installation)
  * [SDK Example Usage](#sdk-example-usage)
  * [Authentication](#authentication)
  * [Available Resources and Operations](#available-resources-and-operations)
  * [Error Handling](#error-handling)
  * [Server Selection](#server-selection)
  * [Custom HTTP Client](#custom-http-client)
* [Development](#development)
  * [Maturity](#maturity)
  * [Contributions](#contributions)
  * [License](#license)
  * [See Also](#see-also)

<!-- End Table of Contents [toc] -->

## SDK Installation

Install the Newline SDK as a package in your .NET project:

```bash
dotnet package add Newline53.sdk
```

<!-- No SDK Installation [installation] -->

<!-- Start SDK Example Usage [usage] -->
## SDK Example Usage

### Example

```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Auth.GenerateTokenAsync();

// handle response
```
<!-- End SDK Example Usage [usage] -->

<!-- Start Authentication [security] -->
## Authentication

### Per-Client Security Schemes

This SDK supports the following security scheme globally:

| Name                       | Type | Scheme      |
| -------------------------- | ---- | ----------- |
| `ProgramUid`<br/>`HmacKey` | http | Custom HTTP |

You can set the security parameters through the `security` optional parameter when initializing the SDK client instance. For example:
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Auth.GenerateTokenAsync();

// handle response
```
<!-- End Authentication [security] -->

<!-- Start Available Resources and Operations [operations] -->
## Available Resources and Operations

<details open>
<summary>Available methods</summary>

### [Auth](docs/sdks/auth/README.md)

* [GenerateToken](docs/sdks/auth/README.md#generatetoken) - Generate an authentication token

### [CombinedTransfers](docs/sdks/combinedtransfers/README.md)

* [List](docs/sdks/combinedtransfers/README.md#list) - List Combined Transfers
* [Create](docs/sdks/combinedtransfers/README.md#create) - Create a new Combined Transfer
* [Get](docs/sdks/combinedtransfers/README.md#get) - Get a single Combined Transfer

### [CustodialAccounts](docs/sdks/custodialaccounts/README.md)

* [List](docs/sdks/custodialaccounts/README.md#list) - List Custodial Accounts
* [Get](docs/sdks/custodialaccounts/README.md#get) - Get a single Custodial Account
* [ListClosingBalances](docs/sdks/custodialaccounts/README.md#listclosingbalances) - List Custodial Account Closing Balances
* [GetClosingBalance](docs/sdks/custodialaccounts/README.md#getclosingbalance) - Get a single Custodial Account Closing Balance

### [CustomerProducts](docs/sdks/customerproducts/README.md)

* [List](docs/sdks/customerproducts/README.md#list) - List Customer Products
* [Onboard](docs/sdks/customerproducts/README.md#onboard) - Onboard Customer onto a Product
* [Get](docs/sdks/customerproducts/README.md#get) - Get a single Customer Product

### [Customers](docs/sdks/customers/README.md)

* [List](docs/sdks/customers/README.md#list) - Get a list of Customers
* [Create](docs/sdks/customers/README.md#create) - Create a new Customer
* [Get](docs/sdks/customers/README.md#get) - Get a single Customer
* [Update](docs/sdks/customers/README.md#update) - Adjust Customer Data
* [Archive](docs/sdks/customers/README.md#archive) - Archive a Customer

### [Pools](docs/sdks/pools/README.md)

* [List](docs/sdks/pools/README.md#list) - List Pools
* [Get](docs/sdks/pools/README.md#get) - Get a single Pool

### [Products](docs/sdks/products/README.md)

* [List](docs/sdks/products/README.md#list) - List Products
* [Get](docs/sdks/products/README.md#get) - Get a single Product

### [Returns](docs/sdks/returns/README.md)

* [List](docs/sdks/returns/README.md#list) - List Returns
* [Create](docs/sdks/returns/README.md#create) - Create a new Return
* [Get](docs/sdks/returns/README.md#get) - Get a single Return

### [SyntheticAccounts](docs/sdks/syntheticaccounts/README.md)

* [ListTypes](docs/sdks/syntheticaccounts/README.md#listtypes) - List Synthetic Account Types
* [GetAccountType](docs/sdks/syntheticaccounts/README.md#getaccounttype) - Get a Single Synthetic Account Type
* [List](docs/sdks/syntheticaccounts/README.md#list) - List Synthetic Accounts
* [Create](docs/sdks/syntheticaccounts/README.md#create) - Create a New Synthetic Account
* [Get](docs/sdks/syntheticaccounts/README.md#get) - Get a single Synthetic Account
* [Update](docs/sdks/syntheticaccounts/README.md#update) - Update the Synthetic Account metadata
* [Archive](docs/sdks/syntheticaccounts/README.md#archive) - Archive a Synthetic Account
* [ListClosingBalances](docs/sdks/syntheticaccounts/README.md#listclosingbalances) - List Synthetic Account Closing Balances
* [GetClosingBalance](docs/sdks/syntheticaccounts/README.md#getclosingbalance) - Get a single Synthetic Account Closing Balance

### [Transactions](docs/sdks/transactions/README.md)

* [List](docs/sdks/transactions/README.md#list) - List Transactions
* [Get](docs/sdks/transactions/README.md#get) - Get a single Transaction
* [Authorize](docs/sdks/transactions/README.md#authorize) - Approve or deny a transaction
* [ListEvents](docs/sdks/transactions/README.md#listevents) - List Transaction Events
* [GetEvent](docs/sdks/transactions/README.md#getevent) - Get a single Transaction Event
* [ListSyntheticLines](docs/sdks/transactions/README.md#listsyntheticlines) - List Synthetic Line Items
* [GetSyntheticLineItem](docs/sdks/transactions/README.md#getsyntheticlineitem) - Get a single Synthetic Line Item
* [ListCustodialLines](docs/sdks/transactions/README.md#listcustodiallines) - List Custodial Line Items
* [GetCustodialLineItem](docs/sdks/transactions/README.md#getcustodiallineitem) - Get a single Custodial Line Item

### [Transfers](docs/sdks/transfers/README.md)

* [List](docs/sdks/transfers/README.md#list) - List Transfers
* [Create](docs/sdks/transfers/README.md#create) - Initiate a Transfer
* [Get](docs/sdks/transfers/README.md#get) - Get a single Transfer
* [Cancel](docs/sdks/transfers/README.md#cancel) - Cancel a Transfer

### [VirtualReferenceNumbers](docs/sdks/virtualreferencenumbers/README.md)

* [List](docs/sdks/virtualreferencenumbers/README.md#list) - List Virtual Reference Numbers
* [Create](docs/sdks/virtualreferencenumbers/README.md#create) - Create a new Virtual Reference Number
* [Get](docs/sdks/virtualreferencenumbers/README.md#get) - Get a single Virtual Reference Number
* [Update](docs/sdks/virtualreferencenumbers/README.md#update) - Edit a Virtual Reference Number
* [Archive](docs/sdks/virtualreferencenumbers/README.md#archive) - Archive a single Virtual Reference Number
* [Lock](docs/sdks/virtualreferencenumbers/README.md#lock) - Lock a single Virtual Reference Number
* [Unlock](docs/sdks/virtualreferencenumbers/README.md#unlock) - Unlock a single Virtual Reference Number

</details>
<!-- End Available Resources and Operations [operations] -->

<!-- Start Error Handling [errors] -->
## Error Handling

[`NewlineSDKException`](./src/Newline53/Sdk/Models/Errors/NewlineSDKException.cs) is the base exception class for all HTTP error responses. It has the following properties:

| Property      | Type                  | Description           |
|---------------|-----------------------|-----------------------|
| `Message`     | *string*              | Error message         |
| `Request`     | *HttpRequestMessage*  | HTTP request object   |
| `Response`    | *HttpResponseMessage* | HTTP response object  |

Some exceptions in this SDK include an additional `Payload` field, which will contain deserialized custom error data when present. Possible exceptions are listed in the [Error Classes](#error-classes) section.

### Example

```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Errors;
using Newline53.Sdk.Models.Requests;
using System.Collections.Generic;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

try
{
    OnboardCustomerProductRequest req = new OnboardCustomerProductRequest() {
        CustomerUid = "S62MaHx6WwsqG9vQ",
        ProductUid = "pQtTCSXz57fuefzp",
    };

    var res = await sdk.CustomerProducts.OnboardAsync(req);

    // handle response
}
catch (NewlineSDKException ex) // all SDK exceptions inherit from NewlineSDKException
{
    // ex.ToString() provides a detailed error message
    System.Console.WriteLine(ex);

    // Base exception fields
    HttpRequestMessage request = ex.Request;
    HttpResponseMessage response = ex.Response;
    var statusCode = (int)response.StatusCode;
    var responseBody = ex.Body;

    if (ex is OnboardCustomerProductUnprocessableEntityException) // different exceptions may be thrown depending on the method
    {
        // Check error data fields
        OnboardCustomerProductUnprocessableEntityExceptionPayload payload = ex.Payload;
        List<OnboardCustomerProductError> Errors = payload.Errors;
        long Status = payload.Status;
        // ...
    }

    // An underlying cause may be provided
    if (ex.InnerException != null)
    {
        Exception cause = ex.InnerException;
    }
}
catch (OperationCanceledException ex)
{
    // CancellationToken was cancelled
}
catch (System.Net.Http.HttpRequestException ex)
{
    // Check ex.InnerException for Network connectivity errors
}
```

### Error Classes

**Primary exception:**
* [`NewlineSDKException`](./src/Newline53/Sdk/Models/Errors/NewlineSDKException.cs): The base class for HTTP error responses.

<details><summary>Less common exceptions (35)</summary>

* [`System.Net.Http.HttpRequestException`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httprequestexception): Network connectivity error. For more details about the underlying cause, inspect the `ex.InnerException`.

* Inheriting from [`NewlineSDKException`](./src/Newline53/Sdk/Models/Errors/NewlineSDKException.cs):
  * [`UpdateSyntheticAccountBadRequestException`](./src/Newline53/Sdk/Models/Errors/UpdateSyntheticAccountBadRequestException.cs): A Synthetic Account is not updated if a required parameter is missing. Status code `400`. Applicable to 1 of 52 methods.*
  * [`PutTransfersUidCancelBadRequestException`](./src/Newline53/Sdk/Models/Errors/PutTransfersUidCancelBadRequestException.cs): The transfer is not eligible for cancellation. Status code `400`. Applicable to 1 of 52 methods.*
  * [`PutTransactionsUidAuthorizeBadRequestException`](./src/Newline53/Sdk/Models/Errors/PutTransactionsUidAuthorizeBadRequestException.cs): Bad authorization request. Status code `400`. Applicable to 1 of 52 methods.*
  * [`PostVirtualReferenceNumbersBadRequestException`](./src/Newline53/Sdk/Models/Errors/PostVirtualReferenceNumbersBadRequestException.cs): Bad request. Status code `400`. Applicable to 1 of 52 methods.*
  * [`PostReturnsBadRequestException`](./src/Newline53/Sdk/Models/Errors/PostReturnsBadRequestException.cs): Creation Error. Status code `400`. Applicable to 1 of 52 methods.*
  * [`PutTransactionsUidAuthorizeForbiddenException`](./src/Newline53/Sdk/Models/Errors/PutTransactionsUidAuthorizeForbiddenException.cs): Client authorization disabled. (The Program is not configured for Client Authorization). Status code `403`. Applicable to 1 of 52 methods.*
  * [`GetReturnsForbiddenException`](./src/Newline53/Sdk/Models/Errors/GetReturnsForbiddenException.cs): Denied access to Returns. Status code `403`. Applicable to 1 of 52 methods.*
  * [`PostReturnsForbiddenException`](./src/Newline53/Sdk/Models/Errors/PostReturnsForbiddenException.cs): Denied access to Returns. Status code `403`. Applicable to 1 of 52 methods.*
  * [`GetReturnsUidForbiddenException`](./src/Newline53/Sdk/Models/Errors/GetReturnsUidForbiddenException.cs): Denied access to Returns. Status code `403`. Applicable to 1 of 52 methods.*
  * [`GetCombinedTransfersForbiddenException`](./src/Newline53/Sdk/Models/Errors/GetCombinedTransfersForbiddenException.cs): Denied access to Combined Transfers. Status code `403`. Applicable to 1 of 52 methods.*
  * [`PostCombinedTransfersForbiddenException`](./src/Newline53/Sdk/Models/Errors/PostCombinedTransfersForbiddenException.cs): Denied access to Combined Transfers. Status code `403`. Applicable to 1 of 52 methods.*
  * [`GetCombinedTransfersUidForbiddenException`](./src/Newline53/Sdk/Models/Errors/GetCombinedTransfersUidForbiddenException.cs): Denied access to Combined Transfers. Status code `403`. Applicable to 1 of 52 methods.*
  * [`GetVirtualReferenceNumbersUidNotFoundException`](./src/Newline53/Sdk/Models/Errors/GetVirtualReferenceNumbersUidNotFoundException.cs): The Virtual Reference Number is not found. Status code `404`. Applicable to 1 of 52 methods.*
  * [`PutVirtualReferenceNumbersUidNotFoundException`](./src/Newline53/Sdk/Models/Errors/PutVirtualReferenceNumbersUidNotFoundException.cs): The Virtual Reference Number is not found. Status code `404`. Applicable to 1 of 52 methods.*
  * [`DeleteVirtualReferenceNumbersUidNotFoundException`](./src/Newline53/Sdk/Models/Errors/DeleteVirtualReferenceNumbersUidNotFoundException.cs): The Virtual Reference Number is not found. Status code `404`. Applicable to 1 of 52 methods.*
  * [`PutVirtualReferenceNumbersUidLockNotFoundException`](./src/Newline53/Sdk/Models/Errors/PutVirtualReferenceNumbersUidLockNotFoundException.cs): The Virtual Reference Number is not found. Status code `404`. Applicable to 1 of 52 methods.*
  * [`PutVirtualReferenceNumbersUidUnlockNotFoundException`](./src/Newline53/Sdk/Models/Errors/PutVirtualReferenceNumbersUidUnlockNotFoundException.cs): The Virtual Reference Number is not found. Status code `404`. Applicable to 1 of 52 methods.*
  * [`GetReturnsUidNotFoundException`](./src/Newline53/Sdk/Models/Errors/GetReturnsUidNotFoundException.cs): Unknown Return. Status code `404`. Applicable to 1 of 52 methods.*
  * [`GetCombinedTransfersUidNotFoundException`](./src/Newline53/Sdk/Models/Errors/GetCombinedTransfersUidNotFoundException.cs): The Combined Transfer is not found. Status code `404`. Applicable to 1 of 52 methods.*
  * [`ConflictException`](./src/Newline53/Sdk/Models/Errors/ConflictException.cs): A new Synthetic Account is NOT created if the external_uid given is present but not unique. Status code `409`. Applicable to 1 of 52 methods.*
  * [`OnboardCustomerProductUnprocessableEntityException`](./src/Newline53/Sdk/Models/Errors/OnboardCustomerProductUnprocessableEntityException.cs): There was a problem with the request body. Status code `422`. Applicable to 1 of 52 methods.*
  * [`DeleteSyntheticAccountUnprocessableEntityException`](./src/Newline53/Sdk/Models/Errors/DeleteSyntheticAccountUnprocessableEntityException.cs): A Synthetic Account is not archived. Status code `422`. Applicable to 1 of 52 methods.*
  * [`PutTransfersUidCancelUnprocessableEntityException`](./src/Newline53/Sdk/Models/Errors/PutTransfersUidCancelUnprocessableEntityException.cs): The transfer could not be canceled. Status code `422`. Applicable to 1 of 52 methods.*
  * [`PutTransactionsUidAuthorizeUnprocessableEntityException`](./src/Newline53/Sdk/Models/Errors/PutTransactionsUidAuthorizeUnprocessableEntityException.cs): An exception occurred while authorizing transaction. Status code `422`. Applicable to 1 of 52 methods.*
  * [`GetVirtualReferenceNumbersUnprocessableEntityException`](./src/Newline53/Sdk/Models/Errors/GetVirtualReferenceNumbersUnprocessableEntityException.cs): Failed to retrieve Virtual Reference Numbers. Status code `422`. Applicable to 1 of 52 methods.*
  * [`PostVirtualReferenceNumbersUnprocessableEntityException`](./src/Newline53/Sdk/Models/Errors/PostVirtualReferenceNumbersUnprocessableEntityException.cs): Creation Error. Status code `422`. Applicable to 1 of 52 methods.*
  * [`PutVirtualReferenceNumbersUidUnprocessableEntityException`](./src/Newline53/Sdk/Models/Errors/PutVirtualReferenceNumbersUidUnprocessableEntityException.cs): Failed to update Virtual Reference Number. Status code `422`. Applicable to 1 of 52 methods.*
  * [`PutVirtualReferenceNumbersUidLockUnprocessableEntityException`](./src/Newline53/Sdk/Models/Errors/PutVirtualReferenceNumbersUidLockUnprocessableEntityException.cs): The Virtual Reference Number could not be locked. Status code `422`. Applicable to 1 of 52 methods.*
  * [`PutVirtualReferenceNumbersUidUnlockUnprocessableEntityException`](./src/Newline53/Sdk/Models/Errors/PutVirtualReferenceNumbersUidUnlockUnprocessableEntityException.cs): The Virtual Reference Number could not be unlocked. Status code `422`. Applicable to 1 of 52 methods.*
  * [`GetReturnsUnprocessableEntityException`](./src/Newline53/Sdk/Models/Errors/GetReturnsUnprocessableEntityException.cs): Failed to retrieve Returns. Status code `422`. Applicable to 1 of 52 methods.*
  * [`PostReturnsUnprocessableEntityException`](./src/Newline53/Sdk/Models/Errors/PostReturnsUnprocessableEntityException.cs): Creation Error. Status code `422`. Applicable to 1 of 52 methods.*
  * [`GetCombinedTransfersUnprocessableEntityException`](./src/Newline53/Sdk/Models/Errors/GetCombinedTransfersUnprocessableEntityException.cs): Failed to retrieve Combined Transfers. Status code `422`. Applicable to 1 of 52 methods.*
  * [`PostCombinedTransfersUnprocessableEntityException`](./src/Newline53/Sdk/Models/Errors/PostCombinedTransfersUnprocessableEntityException.cs): Creation Error. Status code `422`. Applicable to 1 of 52 methods.*
  * [`ResponseValidationError`](./src/Newline53/Sdk/Models/Errors/ResponseValidationError.cs): Thrown when the response data could not be deserialized into the expected type.
</details>

\* Refer to the [relevant documentation](#available-resources-and-operations) to determine whether an exception applies to a specific operation.
<!-- End Error Handling [errors] -->

<!-- Start Server Selection [server] -->
## Server Selection

### Select Server by Name

You can override the default server globally by passing a server name to the `server: string` optional parameter when initializing the SDK client instance. The selected server will then be used as the default on the operations that use it. This table lists the names associated with the available servers:

| Name      | Server                                 | Description |
| --------- | -------------------------------------- | ----------- |
| `sandbox` | `https://sandbox.newline53.com/api/v1` | Sandbox     |
| `prod`    | `https://api.newline53.com/api/v1`     | Production  |

#### Example

```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(
    server: SDKConfig.Server.Sandbox,
    security: new Security() {
        ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
        HmacKey = "<YOUR_HMAC_KEY_HERE>",
    }
);

var res = await sdk.Auth.GenerateTokenAsync();

// handle response
```

### Override Server URL Per-Client

The default server can also be overridden globally by passing a URL to the `serverUrl: string` optional parameter when initializing the SDK client instance. For example:
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(
    serverUrl: "https://sandbox.newline53.com/api/v1",
    security: new Security() {
        ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
        HmacKey = "<YOUR_HMAC_KEY_HERE>",
    }
);

var res = await sdk.Auth.GenerateTokenAsync();

// handle response
```
<!-- End Server Selection [server] -->

<!-- Start Custom HTTP Client [http-client] -->
## Custom HTTP Client

The C# SDK makes API calls using an `ISpeakeasyHttpClient` that wraps the native
[HttpClient](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient). This
client provides the ability to attach hooks around the request lifecycle that can be used to modify the request or handle
errors and response.

The `ISpeakeasyHttpClient` interface allows you to either use the default `SpeakeasyHttpClient` that comes with the SDK,
or provide your own custom implementation with customized configuration such as custom message handlers, timeouts,
connection pooling, and other HTTP client settings.

The following example shows how to create a custom HTTP client with request modification and error handling:

```csharp
using Newline53.Sdk;
using Newline53.Sdk.Utils;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

// Create a custom HTTP client
public class CustomHttpClient : ISpeakeasyHttpClient
{
    private readonly ISpeakeasyHttpClient _defaultClient;

    public CustomHttpClient()
    {
        _defaultClient = new SpeakeasyHttpClient();
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
    {
        // Add custom header and timeout
        request.Headers.Add("x-custom-header", "custom value");
        request.Headers.Add("x-request-timeout", "30");
        
        try
        {
            var response = await _defaultClient.SendAsync(request, cancellationToken);
            // Log successful response
            Console.WriteLine($"Request successful: {response.StatusCode}");
            return response;
        }
        catch (Exception error)
        {
            // Log error
            Console.WriteLine($"Request failed: {error.Message}");
            throw;
        }
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
        _defaultClient?.Dispose();
    }
}

// Use the custom HTTP client with the SDK
var customHttpClient = new CustomHttpClient();
var sdk = new NewlineSDK(client: customHttpClient);
```

<details>
<summary>You can also provide a completely custom HTTP client with your own configuration:</summary>

```csharp
using Newline53.Sdk.Utils;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

// Custom HTTP client with custom configuration
public class AdvancedHttpClient : ISpeakeasyHttpClient
{
    private readonly HttpClient _httpClient;

    public AdvancedHttpClient()
    {
        var handler = new HttpClientHandler()
        {
            MaxConnectionsPerServer = 10,
            // ServerCertificateCustomValidationCallback = customCertValidation, // Custom SSL validation if needed
        };

        _httpClient = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
    {
        return await _httpClient.SendAsync(request, cancellationToken ?? CancellationToken.None);
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}

var sdk = NewlineSDK.Builder()
    .WithClient(new AdvancedHttpClient())
    .Build();
```
</details>

<details>
<summary>For simple debugging, you can enable request/response logging by implementing a custom client:</summary>

```csharp
public class LoggingHttpClient : ISpeakeasyHttpClient
{
    private readonly ISpeakeasyHttpClient _innerClient;

    public LoggingHttpClient(ISpeakeasyHttpClient innerClient = null)
    {
        _innerClient = innerClient ?? new SpeakeasyHttpClient();
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
    {
        // Log request
        Console.WriteLine($"Sending {request.Method} request to {request.RequestUri}");
        
        var response = await _innerClient.SendAsync(request, cancellationToken);
        
        // Log response
        Console.WriteLine($"Received {response.StatusCode} response");
        
        return response;
    }

    public void Dispose() => _innerClient?.Dispose();
}

var sdk = new NewlineSDK(client: new LoggingHttpClient());
```
</details>

The SDK also provides built-in hook support through the `SDKConfiguration.Hooks` system, which automatically handles
`BeforeRequestAsync`, `AfterSuccessAsync`, and `AfterErrorAsync` hooks for advanced request lifecycle management.
<!-- End Custom HTTP Client [http-client] -->

<!-- Placeholder for Future Speakeasy SDK Sections -->

# Development

## Maturity

This SDK is in beta, and there may be breaking changes between versions without a major version update. Therefore, we recommend pinning usage
to a specific package version. This way, you can install the same version each time without breaking changes unless you are intentionally
looking for the latest version.

## Contributions

While we value open-source contributions to this SDK, this library is generated programmatically. Any manual changes added to internal files will be overwritten on the next generation.
We look forward to hearing your feedback. Feel free to open a PR or an issue with a proof of concept and we'll do our best to include it in a future release.

## License

[Apache 2.0](LICENSE)

## See Also

- [Newline API Documentation](https://developers.newline53.com)
- [Newline MCP Server](https://github.com/newline53/newline-mcp-server)
- [Newline Postman Collections](https://www.postman.com/newline53)
