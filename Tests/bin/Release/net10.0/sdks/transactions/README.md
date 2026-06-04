# Transactions

## Overview

Transactions represent asset movements, such as ACH payments, wire transfers, or card purchases. Track transaction statuses and events through these endpoints.  
**Endpoints:**

- GET [List Transactions: GET /transactions](https://developers.newline53.com/reference/get_transactions)

- GET [Get a single Transaction: GET /transactions/{uid}](https://developers.newline53.com/reference/get_transactions-uid)

- PUT [Approve or deny a Transaction: PUT /transactions/{uid}/authorize](https://developers.newline53.com/reference/put_transactions-uid-authorize)

- GET [List Transaction Events: GET /transaction_events](https://developers.newline53.com/reference/get_transaction-events)

- GET [Get a single Transaction Event: GET /transaction_events/{uid}](https://developers.newline53.com/reference/get_transaction-events-uid)

- GET [List Synthetic Line Items: GET /synthetic_line_items](https://developers.newline53.com/reference/get_synthetic-line-items)

- GET [Get a single Synthetic Line Item: GET /synthetic_line_items/{uid}](https://developers.newline53.com/reference/get_synthetic-line-items-uid)

- GET [List Custodial Line Items: GET /custodial_line_items](https://developers.newline53.com/reference/get_custodial-line-items)

- GET [Get a single Custodial Line Item: GET /custodial_line_items/{uid}](https://developers.newline53.com/reference/get_custodial-line-items-uid)

Transactions are created based on how you instruct Newline to move assets (a Transfer) or how assets are moved or spent outside your application (ATM withdrawals, debit card purchases, wire transfers, etc…). The Transaction contains the amount, origin, and destination of assets. Newline categorizes Transactions into types to assist in their classification and representation.

Transactions fall into many categories, including debit card purchases, direct deposits, interest, and fees. This endpoint can retrieve a list of Transactions or track the status of an ongoing Transaction.

Transaction Events are created as a result of a Transaction. They capture the steps required to complete the Transaction. These can be used to view the progress of an in-flight Transaction or see the history of a completed Transaction.

Line Items are created for each Transaction Event. They catalog the individual credits and debits associated with the accounts involved in the Transaction.

### Available Operations

* [List](#list) - List Transactions
* [Get](#get) - Get a single Transaction
* [Authorize](#authorize) - Approve or deny a transaction
* [ListEvents](#listevents) - List Transaction Events
* [GetEvent](#getevent) - Get a single Transaction Event
* [ListSyntheticLines](#listsyntheticlines) - List Synthetic Line Items
* [GetSyntheticLineItem](#getsyntheticlineitem) - Get a single Synthetic Line Item
* [ListCustodialLines](#listcustodiallines) - List Custodial Line Items
* [GetCustodialLineItem](#getcustodiallineitem) - Get a single Custodial Line Item

## List

Retrieves a list of Transactions. Transactions representing expired authorizations or expired reversals are suppressed by default.

### Example Usage: transactions

<!-- UsageSnippet language="csharp" operationID="get_/transactions" method="get" path="/transactions" example="transactions" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;
using System;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

GetTransactionsRequest req = new GetTransactionsRequest() {
    CustomerUid = "uKxmLxUEiSj5h4M3",
    PoolUid = "wTSMX1GubP21ev2h",
    SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
    DestinationSyntheticAccountUid = "exMDShw6yM3NHLYV",
    SyntheticAccountUid = "4XkJnsfHsuqrxmeX",
    Type = GetTransactionsQueryParamType.Ach,
    HasReturn = true,
    ShowDeniedAuths = true,
    ShowExpired = true,
    SearchDescription = "Transfer*",
    IncludeZero = true,
    CreatedAtAfter = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    CreatedAtBefore = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    SettledAtAfter = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    SettledAtBefore = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    InitialActionAtAfter = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    InitialActionAtBefore = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    SettledIndexAfter = 123,
    SettledIndexBefore = 123,
    IdAfter = 123,
    IdBefore = 123,
};

var res = await sdk.Transactions.ListAsync(req);

// handle response
```
### Example Usage: transactions_with_denials

<!-- UsageSnippet language="csharp" operationID="get_/transactions" method="get" path="/transactions" example="transactions_with_denials" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;
using System;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

GetTransactionsRequest req = new GetTransactionsRequest() {
    CustomerUid = "uKxmLxUEiSj5h4M3",
    PoolUid = "wTSMX1GubP21ev2h",
    SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
    DestinationSyntheticAccountUid = "exMDShw6yM3NHLYV",
    SyntheticAccountUid = "4XkJnsfHsuqrxmeX",
    Type = GetTransactionsQueryParamType.Ach,
    HasReturn = true,
    ShowDeniedAuths = true,
    ShowExpired = true,
    SearchDescription = "Transfer*",
    IncludeZero = true,
    CreatedAtAfter = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    CreatedAtBefore = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    SettledAtAfter = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    SettledAtBefore = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    InitialActionAtAfter = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    InitialActionAtBefore = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    SettledIndexAfter = 123,
    SettledIndexBefore = 123,
    IdAfter = 123,
    IdBefore = 123,
};

var res = await sdk.Transactions.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [GetTransactionsRequest](../../Models/Requests/GetTransactionsRequest.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[GetTransactionsResponse](../../Models/Requests/GetTransactionsResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## Get

Retrieves a single Transaction resource along with its details, including amount, origin, destination, and status.

### Example Usage: ach_transaction

<!-- UsageSnippet language="csharp" operationID="get_/transactions/{uid}" method="get" path="/transactions/{uid}" example="ach_transaction" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transactions.GetAsync(uid: "<id>");

// handle response
```
### Example Usage: initiated_ach_return

<!-- UsageSnippet language="csharp" operationID="get_/transactions/{uid}" method="get" path="/transactions/{uid}" example="initiated_ach_return" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transactions.GetAsync(uid: "<id>");

// handle response
```
### Example Usage: initiated_wire_return

<!-- UsageSnippet language="csharp" operationID="get_/transactions/{uid}" method="get" path="/transactions/{uid}" example="initiated_wire_return" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transactions.GetAsync(uid: "<id>");

// handle response
```
### Example Usage: instant_payment_transaction

<!-- UsageSnippet language="csharp" operationID="get_/transactions/{uid}" method="get" path="/transactions/{uid}" example="instant_payment_transaction" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transactions.GetAsync(uid: "<id>");

// handle response
```
### Example Usage: wire_transaction

<!-- UsageSnippet language="csharp" operationID="get_/transactions/{uid}" method="get" path="/transactions/{uid}" example="wire_transaction" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transactions.GetAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetTransactionsUidResponse](../../Models/Requests/GetTransactionsUidResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## Authorize

Approves or denies a pending Transaction. This endpoint is used to explicitly authorize or reject a Transaction before it is executed.

### Example Usage: default_routing_error

<!-- UsageSnippet language="csharp" operationID="put_/transactions/{uid}/authorize" method="put" path="/transactions/{uid}/authorize" example="default_routing_error" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transactions.AuthorizeAsync(
    uid: "<id>",
    body: new PutTransactionsUidAuthorizeRequestBody() {
        AuthorizationStatus = AuthorizationStatusRequest.ClientDenied,
    }
);

// handle response
```
### Example Usage: transaction_authorization_decision_window_expired

<!-- UsageSnippet language="csharp" operationID="put_/transactions/{uid}/authorize" method="put" path="/transactions/{uid}/authorize" example="transaction_authorization_decision_window_expired" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transactions.AuthorizeAsync(
    uid: "<id>",
    body: new PutTransactionsUidAuthorizeRequestBody() {
        AuthorizationStatus = AuthorizationStatusRequest.ClientDenied,
    }
);

// handle response
```
### Example Usage: transaction_authorization_error

<!-- UsageSnippet language="csharp" operationID="put_/transactions/{uid}/authorize" method="put" path="/transactions/{uid}/authorize" example="transaction_authorization_error" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transactions.AuthorizeAsync(
    uid: "<id>",
    body: new PutTransactionsUidAuthorizeRequestBody() {
        AuthorizationStatus = AuthorizationStatusRequest.ClientDenied,
    }
);

// handle response
```
### Example Usage: transaction_authorization_status_error

<!-- UsageSnippet language="csharp" operationID="put_/transactions/{uid}/authorize" method="put" path="/transactions/{uid}/authorize" example="transaction_authorization_status_error" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transactions.AuthorizeAsync(
    uid: "<id>",
    body: new PutTransactionsUidAuthorizeRequestBody() {
        AuthorizationStatus = AuthorizationStatusRequest.ClientDenied,
    }
);

// handle response
```
### Example Usage: transaction_ineligible_for_authorization

<!-- UsageSnippet language="csharp" operationID="put_/transactions/{uid}/authorize" method="put" path="/transactions/{uid}/authorize" example="transaction_ineligible_for_authorization" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transactions.AuthorizeAsync(
    uid: "<id>",
    body: new PutTransactionsUidAuthorizeRequestBody() {
        AuthorizationStatus = AuthorizationStatusRequest.ClientDenied,
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                 | Type                                                                                                      | Required                                                                                                  | Description                                                                                               |
| --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| `Uid`                                                                                                     | *string*                                                                                                  | :heavy_check_mark:                                                                                        | Newline-generated unique id resource specific to the current endpoint                                     |
| `Body`                                                                                                    | [PutTransactionsUidAuthorizeRequestBody](../../Models/Requests/PutTransactionsUidAuthorizeRequestBody.md) | :heavy_check_mark:                                                                                        | N/A                                                                                                       |

### Response

**[PutTransactionsUidAuthorizeResponse](../../Models/Requests/PutTransactionsUidAuthorizeResponse.md)**

### Errors

| Error Type                                                                          | Status Code                                                                         | Content Type                                                                        |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| Newline53.Sdk.Models.Errors.PutTransactionsUidAuthorizeBadRequestException          | 400                                                                                 | application/json                                                                    |
| Newline53.Sdk.Models.Errors.PutTransactionsUidAuthorizeForbiddenException           | 403                                                                                 | application/json                                                                    |
| Newline53.Sdk.Models.Errors.PutTransactionsUidAuthorizeUnprocessableEntityException | 422                                                                                 | application/json                                                                    |
| Newline53.Sdk.Models.Errors.APIException                                            | 4XX, 5XX                                                                            | \*/\*                                                                               |

## ListEvents

Retrieves a list of Transaction Events. Transaction Events represent the steps required to complete a Transaction and can be used to track its progress or review its history.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get_/transaction_events" method="get" path="/transaction_events" example="transactionEvents" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

GetTransactionEventsRequest req = new GetTransactionEventsRequest() {
    SourceCustodialAccountUid = "dmRtw1xkS9ghrntB",
    DestinationCustodialAccountUid = "W55zKgvAk3zkpGM3",
    CustodialAccountUid = "dmRtw1xkS9ghrntB",
    Type = GetTransactionEventsQueryParamType.OdfiAchDeposit,
    TransactionUid = "SMwKC1osz77DTEiu",
};

var res = await sdk.Transactions.ListEventsAsync(req);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `request`                                                                           | [GetTransactionEventsRequest](../../Models/Requests/GetTransactionEventsRequest.md) | :heavy_check_mark:                                                                  | The request object to use for the request.                                          |

### Response

**[GetTransactionEventsResponse](../../Models/Requests/GetTransactionEventsResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## GetEvent

Retrieves a single Transaction Event resource, including its status, timestamps, and associated Transaction details.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get_/transaction_events/{uid}" method="get" path="/transaction_events/{uid}" example="transactionEvent" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transactions.GetEventAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetTransactionEventsUidResponse](../../Models/Requests/GetTransactionEventsUidResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## ListSyntheticLines

Retrieves a list of Synthetic Line Items. These represent individual debits and credits associated with Synthetic Accounts as part of a Transaction Event.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get_/synthetic_line_items" method="get" path="/synthetic_line_items" example="syntheticLineItems" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

GetSyntheticLineItemsRequest req = new GetSyntheticLineItemsRequest() {
    CustomerUid = "uKxmLxUEiSj5h4M3",
    PoolUid = "wTSMX1GubP21ev2h",
    SyntheticAccountUid = "4XkJnsfHsuqrxmeX",
    TransactionUid = "SMwKC1osz77DTEiu",
};

var res = await sdk.Transactions.ListSyntheticLinesAsync(req);

// handle response
```

### Parameters

| Parameter                                                                             | Type                                                                                  | Required                                                                              | Description                                                                           |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `request`                                                                             | [GetSyntheticLineItemsRequest](../../Models/Requests/GetSyntheticLineItemsRequest.md) | :heavy_check_mark:                                                                    | The request object to use for the request.                                            |

### Response

**[GetSyntheticLineItemsResponse](../../Models/Requests/GetSyntheticLineItemsResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## GetSyntheticLineItem

Retrieves a single Synthetic Line Item resource, including the amount, account, and associated Transaction Event.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get_/synthetic_line_items/{uid}" method="get" path="/synthetic_line_items/{uid}" example="syntheticLineItem" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transactions.GetSyntheticLineItemAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetSyntheticLineItemsUidResponse](../../Models/Requests/GetSyntheticLineItemsUidResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## ListCustodialLines

Retrieves a list of Custodial Line Items. These represent individual debits and credits associated with Custodial Accounts as part of a Transaction Event.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get_/custodial_line_items" method="get" path="/custodial_line_items" example="custodialLineItems" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

GetCustodialLineItemsRequest req = new GetCustodialLineItemsRequest() {
    CustomerUid = "uKxmLxUEiSj5h4M3",
    CustodialAccountUid = "dmRtw1xkS9ghrntB",
    TransactionEventUid = "MB2yqBrm3c4bUbou",
    TransactionUid = "SMwKC1osz77DTEiu",
};

var res = await sdk.Transactions.ListCustodialLinesAsync(req);

// handle response
```

### Parameters

| Parameter                                                                             | Type                                                                                  | Required                                                                              | Description                                                                           |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `request`                                                                             | [GetCustodialLineItemsRequest](../../Models/Requests/GetCustodialLineItemsRequest.md) | :heavy_check_mark:                                                                    | The request object to use for the request.                                            |

### Response

**[GetCustodialLineItemsResponse](../../Models/Requests/GetCustodialLineItemsResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## GetCustodialLineItem

Retrieves a single Custodial Line Item resource, including the amount, account, and associated Transaction Event.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get_/custodial_line_items/{uid}" method="get" path="/custodial_line_items/{uid}" example="custodialLineItem" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transactions.GetCustodialLineItemAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetCustodialLineItemsUidResponse](../../Models/Requests/GetCustodialLineItemsUidResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |