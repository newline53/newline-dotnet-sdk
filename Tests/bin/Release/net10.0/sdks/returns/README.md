# Returns

## Overview

The Returns endpoints help initiate, track, and manage returns of received and originated payments. These endpoints are accessible within the Sandbox and Production environments.

**Endpoints:**

- GET [List Returns: GET /returns](https://developers.newline53.com/reference/get_returns)
- POST [Create a new Return: POST /returns](https://developers.newline53.com/reference/post_returns)
- GET [Get a single Return: GET /returns/{uid}](https://developers.newline53.com/reference/get_returns-uid)

The returns endpoint allows for the retrieval and creation of return transactions within the system.

[GET List Returns](https://newline-enterprise-group.readme.io/reference/get_returns)- Use this endpoint to retrieve a list of all return transactions. You can filter the results based on various parameters such as status or date.

[POST Create a New Return](https://newline-enterprise-group.readme.io/reference/post_returns)- This endpoint is used to Create a new return transaction. Return can only be created for eligible transactions that have already been completed.

[GET a Single Return](https://newline-enterprise-group.readme.io/reference/get_returns-uid)- Use this endpoint to retrieve details about a specific return transaction.

### Available Operations

* [List](#list) - List Returns
* [Create](#create) - Create a new Return
* [Get](#get) - Get a single Return

## List

Retrieves a list of return transactions. You can filter the results based on parameters such as status, date, and transaction type. This endpoint is available in Sandbox and Production environments.


### Example Usage

<!-- UsageSnippet language="csharp" operationID="get_/returns" method="get" path="/returns" example="returns_list" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Returns.ListAsync(
    customerUid: "Trzqy9t6j6tFGoG3",
    requestorType: QueryParamRequestorType.Customer
);

// handle response
```

### Parameters

| Parameter                                                                   | Type                                                                        | Required                                                                    | Description                                                                 | Example                                                                     |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `CustomerUid`                                                               | *string*                                                                    | :heavy_minus_sign:                                                          | N/A                                                                         | Trzqy9t6j6tFGoG3                                                            |
| `RequestorType`                                                             | [QueryParamRequestorType](../../Models/Requests/QueryParamRequestorType.md) | :heavy_minus_sign:                                                          | Type of the customer requesting a return.                                   | customer                                                                    |

### Response

**[GetReturnsResponse](../../Models/Requests/GetReturnsResponse.md)**

### Errors

| Error Type                                                         | Status Code                                                        | Content Type                                                       |
| ------------------------------------------------------------------ | ------------------------------------------------------------------ | ------------------------------------------------------------------ |
| Newline53.Sdk.Models.Errors.GetReturnsForbiddenException           | 403                                                                | application/json                                                   |
| Newline53.Sdk.Models.Errors.GetReturnsUnprocessableEntityException | 422                                                                | application/json                                                   |
| Newline53.Sdk.Models.Errors.APIException                           | 4XX, 5XX                                                           | \*/\*                                                              |

## Create

Initiates a Return of an ACH or wire payment.
A full ACH addenda is not available for ACH returns because an addenda record is used for the return itself; the `addenda_info` field contains the remaining available space.
For wire returns, the `wire_instruction` field is limited to 70 characters because Newline prefixes the instructions with the original wire transaction identifier (e.g., IMAD).


### Example Usage: access_to_returns

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="access_to_returns" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    OriginalTransactionUid = "nwXnpBbX3A5sTki3",
    RequestingCustomerUid = "Trzqy9t6j6tFGoG3",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "Insufficient Funds",
    Ach = new PostReturnsAchRequest() {
        AchReturnCode = AchReturnCodeRequest.R02,
        AddendaInfo = "TXN0055BADD1E cancelled",
    },
    Wire = new PostReturnsWireRequest() {
        WireInstructions = "ORDER 5555555555",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```
### Example Usage: ach

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="ach" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    OriginalTransactionUid = "nwXnpBbX3A5sTki3",
    RequestingCustomerUid = "Trzqy9t6j6tFGoG3",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "RLYGR8CO RMA Z452208-13",
    Ach = new PostReturnsAchRequest() {
        AchReturnCode = AchReturnCodeRequest.R02,
        AddendaInfo = "TXN0055BADD1E cancelled",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```
### Example Usage: bad_original_transaction_status

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="bad_original_transaction_status" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    OriginalTransactionUid = "nwXnpBbX3A5sTki3",
    RequestingCustomerUid = "Trzqy9t6j6tFGoG3",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "Insufficient Funds",
    Ach = new PostReturnsAchRequest() {
        AchReturnCode = AchReturnCodeRequest.R02,
        AddendaInfo = "TXN0055BADD1E cancelled",
    },
    Wire = new PostReturnsWireRequest() {
        WireInstructions = "ORDER 5555555555",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```
### Example Usage: cannot_return_a_return_transaction

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="cannot_return_a_return_transaction" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    OriginalTransactionUid = "nwXnpBbX3A5sTki3",
    RequestingCustomerUid = "Trzqy9t6j6tFGoG3",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "Insufficient Funds",
    Ach = new PostReturnsAchRequest() {
        AchReturnCode = AchReturnCodeRequest.R02,
        AddendaInfo = "TXN0055BADD1E cancelled",
    },
    Wire = new PostReturnsWireRequest() {
        WireInstructions = "ORDER 5555555555",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```
### Example Usage: cannot_return_an_ineligible_transaction

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="cannot_return_an_ineligible_transaction" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    OriginalTransactionUid = "nwXnpBbX3A5sTki3",
    RequestingCustomerUid = "Trzqy9t6j6tFGoG3",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "Insufficient Funds",
    Ach = new PostReturnsAchRequest() {
        AchReturnCode = AchReturnCodeRequest.R02,
        AddendaInfo = "TXN0055BADD1E cancelled",
    },
    Wire = new PostReturnsWireRequest() {
        WireInstructions = "ORDER 5555555555",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```
### Example Usage: created_return

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="created_return" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    OriginalTransactionUid = "nwXnpBbX3A5sTki3",
    RequestingCustomerUid = "Trzqy9t6j6tFGoG3",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "Insufficient Funds",
    Ach = new PostReturnsAchRequest() {
        AchReturnCode = AchReturnCodeRequest.R02,
        AddendaInfo = "TXN0055BADD1E cancelled",
    },
    Wire = new PostReturnsWireRequest() {
        WireInstructions = "ORDER 5555555555",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```
### Example Usage: expired_return_window

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="expired_return_window" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    OriginalTransactionUid = "nwXnpBbX3A5sTki3",
    RequestingCustomerUid = "Trzqy9t6j6tFGoG3",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "Insufficient Funds",
    Ach = new PostReturnsAchRequest() {
        AchReturnCode = AchReturnCodeRequest.R02,
        AddendaInfo = "TXN0055BADD1E cancelled",
    },
    Wire = new PostReturnsWireRequest() {
        WireInstructions = "ORDER 5555555555",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```
### Example Usage: extraneous_payment_rail_info_for_return

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="extraneous_payment_rail_info_for_return" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    OriginalTransactionUid = "nwXnpBbX3A5sTki3",
    RequestingCustomerUid = "Trzqy9t6j6tFGoG3",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "Insufficient Funds",
    Ach = new PostReturnsAchRequest() {
        AchReturnCode = AchReturnCodeRequest.R02,
        AddendaInfo = "TXN0055BADD1E cancelled",
    },
    Wire = new PostReturnsWireRequest() {
        WireInstructions = "ORDER 5555555555",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```
### Example Usage: information_unavailable_for_return

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="information_unavailable_for_return" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    OriginalTransactionUid = "nwXnpBbX3A5sTki3",
    RequestingCustomerUid = "Trzqy9t6j6tFGoG3",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "Insufficient Funds",
    Ach = new PostReturnsAchRequest() {
        AchReturnCode = AchReturnCodeRequest.R02,
        AddendaInfo = "TXN0055BADD1E cancelled",
    },
    Wire = new PostReturnsWireRequest() {
        WireInstructions = "ORDER 5555555555",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```
### Example Usage: insufficient_time_to_process_return

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="insufficient_time_to_process_return" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    OriginalTransactionUid = "nwXnpBbX3A5sTki3",
    RequestingCustomerUid = "Trzqy9t6j6tFGoG3",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "Insufficient Funds",
    Ach = new PostReturnsAchRequest() {
        AchReturnCode = AchReturnCodeRequest.R02,
        AddendaInfo = "TXN0055BADD1E cancelled",
    },
    Wire = new PostReturnsWireRequest() {
        WireInstructions = "ORDER 5555555555",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```
### Example Usage: network_code_unsupported

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="network_code_unsupported" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    OriginalTransactionUid = "nwXnpBbX3A5sTki3",
    RequestingCustomerUid = "Trzqy9t6j6tFGoG3",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "Insufficient Funds",
    Ach = new PostReturnsAchRequest() {
        AchReturnCode = AchReturnCodeRequest.R02,
        AddendaInfo = "TXN0055BADD1E cancelled",
    },
    Wire = new PostReturnsWireRequest() {
        WireInstructions = "ORDER 5555555555",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```
### Example Usage: return_already_exists

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="return_already_exists" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    OriginalTransactionUid = "nwXnpBbX3A5sTki3",
    RequestingCustomerUid = "Trzqy9t6j6tFGoG3",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "Insufficient Funds",
    Ach = new PostReturnsAchRequest() {
        AchReturnCode = AchReturnCodeRequest.R02,
        AddendaInfo = "TXN0055BADD1E cancelled",
    },
    Wire = new PostReturnsWireRequest() {
        WireInstructions = "ORDER 5555555555",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```
### Example Usage: return_creation_error

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="return_creation_error" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    OriginalTransactionUid = "nwXnpBbX3A5sTki3",
    RequestingCustomerUid = "Trzqy9t6j6tFGoG3",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "Insufficient Funds",
    Ach = new PostReturnsAchRequest() {
        AchReturnCode = AchReturnCodeRequest.R02,
        AddendaInfo = "TXN0055BADD1E cancelled",
    },
    Wire = new PostReturnsWireRequest() {
        WireInstructions = "ORDER 5555555555",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```
### Example Usage: unknown_requestor_type

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="unknown_requestor_type" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    OriginalTransactionUid = "nwXnpBbX3A5sTki3",
    RequestingCustomerUid = "Trzqy9t6j6tFGoG3",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "Insufficient Funds",
    Ach = new PostReturnsAchRequest() {
        AchReturnCode = AchReturnCodeRequest.R02,
        AddendaInfo = "TXN0055BADD1E cancelled",
    },
    Wire = new PostReturnsWireRequest() {
        WireInstructions = "ORDER 5555555555",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```
### Example Usage: unsupported_original_transaction_code

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="unsupported_original_transaction_code" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    OriginalTransactionUid = "nwXnpBbX3A5sTki3",
    RequestingCustomerUid = "Trzqy9t6j6tFGoG3",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "Insufficient Funds",
    Ach = new PostReturnsAchRequest() {
        AchReturnCode = AchReturnCodeRequest.R02,
        AddendaInfo = "TXN0055BADD1E cancelled",
    },
    Wire = new PostReturnsWireRequest() {
        WireInstructions = "ORDER 5555555555",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```
### Example Usage: unsupported_return

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="unsupported_return" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    OriginalTransactionUid = "nwXnpBbX3A5sTki3",
    RequestingCustomerUid = "Trzqy9t6j6tFGoG3",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "Insufficient Funds",
    Ach = new PostReturnsAchRequest() {
        AchReturnCode = AchReturnCodeRequest.R02,
        AddendaInfo = "TXN0055BADD1E cancelled",
    },
    Wire = new PostReturnsWireRequest() {
        WireInstructions = "ORDER 5555555555",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```
### Example Usage: wire

<!-- UsageSnippet language="csharp" operationID="post_/returns" method="post" path="/returns" example="wire" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostReturnsRequest req = new PostReturnsRequest() {
    OriginalTransactionUid = "DbxJUHVuqt3C7hGK",
    RequestingCustomerUid = "EhrQZJNjCd79LLYq",
    RequestorType = RequestorTypeRequest.Customer,
    ReturnReason = "Refund issued by Bruno's Boxing for Order #5555555555",
    Wire = new PostReturnsWireRequest() {
        WireInstructions = "ORDER 5555555555",
    },
};

var res = await sdk.Returns.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `request`                                                         | [PostReturnsRequest](../../Models/Requests/PostReturnsRequest.md) | :heavy_check_mark:                                                | The request object to use for the request.                        |

### Response

**[PostReturnsResponse](../../Models/Requests/PostReturnsResponse.md)**

### Errors

| Error Type                                                          | Status Code                                                         | Content Type                                                        |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| Newline53.Sdk.Models.Errors.PostReturnsBadRequestException          | 400                                                                 | application/json                                                    |
| Newline53.Sdk.Models.Errors.PostReturnsForbiddenException           | 403                                                                 | application/json                                                    |
| Newline53.Sdk.Models.Errors.PostReturnsUnprocessableEntityException | 422                                                                 | application/json                                                    |
| Newline53.Sdk.Models.Errors.APIException                            | 4XX, 5XX                                                            | \*/\*                                                               |

## Get

Retrieves details about a specific return transaction, including its status, original transaction reference, and any associated metadata.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get_/returns/{uid}" method="get" path="/returns/{uid}" example="single_return" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Returns.GetAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetReturnsUidResponse](../../Models/Requests/GetReturnsUidResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Newline53.Sdk.Models.Errors.GetReturnsUidForbiddenException | 403                                                         | application/json                                            |
| Newline53.Sdk.Models.Errors.GetReturnsUidNotFoundException  | 404                                                         | application/json                                            |
| Newline53.Sdk.Models.Errors.APIException                    | 4XX, 5XX                                                    | \*/\*                                                       |