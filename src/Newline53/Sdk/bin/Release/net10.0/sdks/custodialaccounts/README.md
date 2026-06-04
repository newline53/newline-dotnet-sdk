# CustodialAccounts

## Overview

### Available Operations

* [List](#list) - List Custodial Accounts
* [Get](#get) - Get a single Custodial Account
* [ListClosingBalances](#listclosingbalances) - List Custodial Account Closing Balances
* [GetClosingBalance](#getclosingbalance) - Get a single Custodial Account Closing Balance

## List

Retrieve a list of Custodial Accounts held by Fifth Third Bank for onboarded Customers. This endpoint returns active and archived accounts along with their balances.


### Example Usage

<!-- UsageSnippet language="csharp" operationID="listCustodialAccounts" method="get" path="/custodial_accounts" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

ListCustodialAccountsRequest req = new ListCustodialAccountsRequest() {
    CustomerUid = "uKxmLxUEiSj5h4M3",
    ExternalUid = "client-generated-id",
    Type = ListCustodialAccountsQueryParamType.Dda,
};

var res = await sdk.CustodialAccounts.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                             | Type                                                                                  | Required                                                                              | Description                                                                           |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `request`                                                                             | [ListCustodialAccountsRequest](../../Models/Requests/ListCustodialAccountsRequest.md) | :heavy_check_mark:                                                                    | The request object to use for the request.                                            |

### Response

**[ListCustodialAccountsResponse](../../Models/Requests/ListCustodialAccountsResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## Get

Returns a single Custodial Account resource along with supporting details and account balances.


### Example Usage

<!-- UsageSnippet language="csharp" operationID="getCustodialAccount" method="get" path="/custodial_accounts/{uid}" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.CustodialAccounts.GetAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetCustodialAccountResponse](../../Models/Requests/GetCustodialAccountResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## ListClosingBalances

Retrieves a paginated list of Custodial Account Closing balances, filtered by various parameters.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="listCustodialAccountClosingBalances" method="get" path="/custodial_account_closing_balances" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;
using System;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

ListCustodialAccountClosingBalancesRequest req = new ListCustodialAccountClosingBalancesRequest() {
    CustodialAccountUid = "yqyYk5b1xgXFFrXs",
    CustodialAccountExternalUid = "4XkJnsfHsuqrxmeX",
    NetUsdClosingBalanceAsOf = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    NetUsdClosingBalanceBefore = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    NetUsdClosingBalanceAfter = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
};

var res = await sdk.CustodialAccounts.ListClosingBalancesAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                                         | Type                                                                                                              | Required                                                                                                          | Description                                                                                                       |
| ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| `request`                                                                                                         | [ListCustodialAccountClosingBalancesRequest](../../Models/Requests/ListCustodialAccountClosingBalancesRequest.md) | :heavy_check_mark:                                                                                                | The request object to use for the request.                                                                        |

### Response

**[ListCustodialAccountClosingBalancesResponse](../../Models/Requests/ListCustodialAccountClosingBalancesResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## GetClosingBalance

Get a single Custodial Account Closing Balance

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getCustodialAccountClosingBalance" method="get" path="/custodial_account_closing_balances/{uid}" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.CustodialAccounts.GetClosingBalanceAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetCustodialAccountClosingBalanceResponse](../../Models/Requests/GetCustodialAccountClosingBalanceResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |