# VirtualReferenceNumbers

## Overview

### Available Operations

* [List](#list) - List Virtual Reference Numbers
* [Create](#create) - Create a new Virtual Reference Number
* [Get](#get) - Get a single Virtual Reference Number
* [Update](#update) - Edit a Virtual Reference Number
* [Archive](#archive) - Archive a single Virtual Reference Number
* [Lock](#lock) - Lock a single Virtual Reference Number
* [Unlock](#unlock) - Unlock a single Virtual Reference Number

## List

Retrieves a list of Virtual Reference Numbers (VRNs) associated with the specified Synthetic Account. Supports filtering by status and other attributes.


### Example Usage

<!-- UsageSnippet language="csharp" operationID="get_/virtual_reference_numbers" method="get" path="/virtual_reference_numbers" example="virtual_reference_numbers_list" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.VirtualReferenceNumbers.ListAsync(
    instantPaymentRailRegistrationStatus: QueryParamInstantPaymentRailRegistrationStatus.Registered,
    status: GetVirtualReferenceNumbersQueryParamStatus.Active,
    syntheticAccountUid: "Dg1EPao8XukUpHG8",
    virtualReferenceNumber: "1234567890123456"
);

// handle response
```

### Parameters

| Parameter                                                                                                                 | Type                                                                                                                      | Required                                                                                                                  | Description                                                                                                               | Example                                                                                                                   |
| ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- |
| `InstantPaymentRailRegistrationStatus`                                                                                    | [QueryParamInstantPaymentRailRegistrationStatus](../../Models/Requests/QueryParamInstantPaymentRailRegistrationStatus.md) | :heavy_minus_sign:                                                                                                        | Registration status with Newline and Fifth Third, for RTP network acceptance.                                             | registered                                                                                                                |
| `Status`                                                                                                                  | [GetVirtualReferenceNumbersQueryParamStatus](../../Models/Requests/GetVirtualReferenceNumbersQueryParamStatus.md)         | :heavy_minus_sign:                                                                                                        | A value indicating the overall state of this VRN.                                                                         | active                                                                                                                    |
| `SyntheticAccountUid`                                                                                                     | *string*                                                                                                                  | :heavy_minus_sign:                                                                                                        | N/A                                                                                                                       | Dg1EPao8XukUpHG8                                                                                                          |
| `VirtualReferenceNumber`                                                                                                  | *string*                                                                                                                  | :heavy_minus_sign:                                                                                                        | N/A                                                                                                                       | 1234567890123456                                                                                                          |

### Response

**[GetVirtualReferenceNumbersResponse](../../Models/Requests/GetVirtualReferenceNumbersResponse.md)**

### Errors

| Error Type                                                                         | Status Code                                                                        | Content Type                                                                       |
| ---------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------- |
| Newline53.Sdk.Models.Errors.GetVirtualReferenceNumbersUnprocessableEntityException | 422                                                                                | application/json                                                                   |
| Newline53.Sdk.Models.Errors.APIException                                           | 4XX, 5XX                                                                           | \*/\*                                                                              |

## Create

Creates a new Virtual Reference Number (VRN) for the specified Synthetic Account.

### Example Usage: create_payload

<!-- UsageSnippet language="csharp" operationID="post_/virtual_reference_numbers" method="post" path="/virtual_reference_numbers" example="create_payload" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostVirtualReferenceNumbersRequest req = new PostVirtualReferenceNumbersRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    Name = "greenfield1",
    SyntheticAccountUid = "Dg1EPao8XukUpHG8",
    RoutingNumber = "123456789",
};

var res = await sdk.VirtualReferenceNumbers.CreateAsync(req);

// handle response
```
### Example Usage: pending

<!-- UsageSnippet language="csharp" operationID="post_/virtual_reference_numbers" method="post" path="/virtual_reference_numbers" example="pending" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostVirtualReferenceNumbersRequest req = new PostVirtualReferenceNumbersRequest() {
    ExternalUid = "partner-generated-id",
    Name = "greenfield1",
    SyntheticAccountUid = "Dg1EPao8XukUpHG8",
    RoutingNumber = "123456789",
};

var res = await sdk.VirtualReferenceNumbers.CreateAsync(req);

// handle response
```
### Example Usage: synthetic_account_ineligible_for_vrn

<!-- UsageSnippet language="csharp" operationID="post_/virtual_reference_numbers" method="post" path="/virtual_reference_numbers" example="synthetic_account_ineligible_for_vrn" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostVirtualReferenceNumbersRequest req = new PostVirtualReferenceNumbersRequest() {
    ExternalUid = "partner-generated-id",
    Name = "greenfield1",
    SyntheticAccountUid = "Dg1EPao8XukUpHG8",
    RoutingNumber = "123456789",
};

var res = await sdk.VirtualReferenceNumbers.CreateAsync(req);

// handle response
```
### Example Usage: vrn_creation_error_sync

<!-- UsageSnippet language="csharp" operationID="post_/virtual_reference_numbers" method="post" path="/virtual_reference_numbers" example="vrn_creation_error_sync" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostVirtualReferenceNumbersRequest req = new PostVirtualReferenceNumbersRequest() {
    ExternalUid = "partner-generated-id",
    Name = "greenfield1",
    SyntheticAccountUid = "Dg1EPao8XukUpHG8",
    RoutingNumber = "123456789",
};

var res = await sdk.VirtualReferenceNumbers.CreateAsync(req);

// handle response
```
### Example Usage: vrn_type_not_allowed

<!-- UsageSnippet language="csharp" operationID="post_/virtual_reference_numbers" method="post" path="/virtual_reference_numbers" example="vrn_type_not_allowed" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostVirtualReferenceNumbersRequest req = new PostVirtualReferenceNumbersRequest() {
    ExternalUid = "partner-generated-id",
    Name = "greenfield1",
    SyntheticAccountUid = "Dg1EPao8XukUpHG8",
    RoutingNumber = "123456789",
};

var res = await sdk.VirtualReferenceNumbers.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                         | Type                                                                                              | Required                                                                                          | Description                                                                                       |
| ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| `request`                                                                                         | [PostVirtualReferenceNumbersRequest](../../Models/Requests/PostVirtualReferenceNumbersRequest.md) | :heavy_check_mark:                                                                                | The request object to use for the request.                                                        |

### Response

**[PostVirtualReferenceNumbersResponse](../../Models/Requests/PostVirtualReferenceNumbersResponse.md)**

### Errors

| Error Type                                                                          | Status Code                                                                         | Content Type                                                                        |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| Newline53.Sdk.Models.Errors.PostVirtualReferenceNumbersBadRequestException          | 400                                                                                 | application/json                                                                    |
| Newline53.Sdk.Models.Errors.PostVirtualReferenceNumbersUnprocessableEntityException | 422                                                                                 | application/json                                                                    |
| Newline53.Sdk.Models.Errors.APIException                                            | 4XX, 5XX                                                                            | \*/\*                                                                               |

## Get

Retrieves a single Virtual Reference Number resource along with its details, including status, linked Synthetic Account, and registration metadata.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get_/virtual_reference_numbers/{uid}" method="get" path="/virtual_reference_numbers/{uid}" example="registered" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.VirtualReferenceNumbers.GetAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetVirtualReferenceNumbersUidResponse](../../Models/Requests/GetVirtualReferenceNumbersUidResponse.md)**

### Errors

| Error Type                                                                 | Status Code                                                                | Content Type                                                               |
| -------------------------------------------------------------------------- | -------------------------------------------------------------------------- | -------------------------------------------------------------------------- |
| Newline53.Sdk.Models.Errors.GetVirtualReferenceNumbersUidNotFoundException | 404                                                                        | application/json                                                           |
| Newline53.Sdk.Models.Errors.APIException                                   | 4XX, 5XX                                                                   | \*/\*                                                                      |

## Update

Updates the metadata of an existing Virtual Reference Number. This may include changes to labels, descriptions, or Instant Payment registration settings.

### Example Usage: failed_to_update_vrn

<!-- UsageSnippet language="csharp" operationID="put_/virtual_reference_numbers/{uid}" method="put" path="/virtual_reference_numbers/{uid}" example="failed_to_update_vrn" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.VirtualReferenceNumbers.UpdateAsync(
    uid: "<id>",
    body: new PutVirtualReferenceNumbersUidRequestBody() {
        ExternalUid = "partner-generated-id",
        Name = "greenfield1",
    }
);

// handle response
```
### Example Usage: registered

<!-- UsageSnippet language="csharp" operationID="put_/virtual_reference_numbers/{uid}" method="put" path="/virtual_reference_numbers/{uid}" example="registered" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.VirtualReferenceNumbers.UpdateAsync(
    uid: "<id>",
    body: new PutVirtualReferenceNumbersUidRequestBody() {
        ExternalUid = "partner-generated-id",
        Name = "greenfield1",
    }
);

// handle response
```
### Example Usage: unknown_virtual_reference_number

<!-- UsageSnippet language="csharp" operationID="put_/virtual_reference_numbers/{uid}" method="put" path="/virtual_reference_numbers/{uid}" example="unknown_virtual_reference_number" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.VirtualReferenceNumbers.UpdateAsync(
    uid: "<id>",
    body: new PutVirtualReferenceNumbersUidRequestBody() {
        ExternalUid = "partner-generated-id",
        Name = "greenfield1",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                     | Type                                                                                                          | Required                                                                                                      | Description                                                                                                   |
| ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| `Uid`                                                                                                         | *string*                                                                                                      | :heavy_check_mark:                                                                                            | Newline-generated unique id resource specific to the current endpoint                                         |
| `Body`                                                                                                        | [PutVirtualReferenceNumbersUidRequestBody](../../Models/Requests/PutVirtualReferenceNumbersUidRequestBody.md) | :heavy_check_mark:                                                                                            | N/A                                                                                                           |

### Response

**[PutVirtualReferenceNumbersUidResponse](../../Models/Requests/PutVirtualReferenceNumbersUidResponse.md)**

### Errors

| Error Type                                                                            | Status Code                                                                           | Content Type                                                                          |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| Newline53.Sdk.Models.Errors.PutVirtualReferenceNumbersUidNotFoundException            | 404                                                                                   | application/json                                                                      |
| Newline53.Sdk.Models.Errors.PutVirtualReferenceNumbersUidUnprocessableEntityException | 422                                                                                   | application/json                                                                      |
| Newline53.Sdk.Models.Errors.APIException                                              | 4XX, 5XX                                                                              | \*/\*                                                                                 |

## Archive

Archives a Virtual Reference Number, removing it from active use. Archived VRNs cannot be used for incoming payments or reconciliation.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="delete_/virtual_reference_numbers/{uid}" method="delete" path="/virtual_reference_numbers/{uid}" example="archived" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.VirtualReferenceNumbers.ArchiveAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[DeleteVirtualReferenceNumbersUidResponse](../../Models/Requests/DeleteVirtualReferenceNumbersUidResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| Newline53.Sdk.Models.Errors.DeleteVirtualReferenceNumbersUidNotFoundException | 404                                                                           | application/json                                                              |
| Newline53.Sdk.Models.Errors.APIException                                      | 4XX, 5XX                                                                      | \*/\*                                                                         |

## Lock

Locks a Virtual Reference Number to prevent new transactions or usage. This is typically used for fraud prevention or temporary deactivation.

### Example Usage: failed_to_update_vrn

<!-- UsageSnippet language="csharp" operationID="put_/virtual_reference_numbers/{uid}/lock" method="put" path="/virtual_reference_numbers/{uid}/lock" example="failed_to_update_vrn" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.VirtualReferenceNumbers.LockAsync(
    uid: "<id>",
    body: new PutVirtualReferenceNumbersUidLockRequestBody() {
        LockReason = LockReasonRequest.Admin,
    }
);

// handle response
```
### Example Usage: locked

<!-- UsageSnippet language="csharp" operationID="put_/virtual_reference_numbers/{uid}/lock" method="put" path="/virtual_reference_numbers/{uid}/lock" example="locked" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.VirtualReferenceNumbers.LockAsync(
    uid: "<id>",
    body: new PutVirtualReferenceNumbersUidLockRequestBody() {
        LockReason = LockReasonRequest.Admin,
    }
);

// handle response
```
### Example Usage: unknown_virtual_reference_number

<!-- UsageSnippet language="csharp" operationID="put_/virtual_reference_numbers/{uid}/lock" method="put" path="/virtual_reference_numbers/{uid}/lock" example="unknown_virtual_reference_number" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.VirtualReferenceNumbers.LockAsync(
    uid: "<id>",
    body: new PutVirtualReferenceNumbersUidLockRequestBody() {
        LockReason = LockReasonRequest.Admin,
    }
);

// handle response
```
### Example Usage: virtual_reference_number_archived

<!-- UsageSnippet language="csharp" operationID="put_/virtual_reference_numbers/{uid}/lock" method="put" path="/virtual_reference_numbers/{uid}/lock" example="virtual_reference_number_archived" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.VirtualReferenceNumbers.LockAsync(
    uid: "<id>",
    body: new PutVirtualReferenceNumbersUidLockRequestBody() {
        LockReason = LockReasonRequest.Admin,
    }
);

// handle response
```
### Example Usage: vrn_already_locked

<!-- UsageSnippet language="csharp" operationID="put_/virtual_reference_numbers/{uid}/lock" method="put" path="/virtual_reference_numbers/{uid}/lock" example="vrn_already_locked" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.VirtualReferenceNumbers.LockAsync(
    uid: "<id>",
    body: new PutVirtualReferenceNumbersUidLockRequestBody() {
        LockReason = LockReasonRequest.Admin,
    }
);

// handle response
```
### Example Usage: vrn_lock_cooldown_active

<!-- UsageSnippet language="csharp" operationID="put_/virtual_reference_numbers/{uid}/lock" method="put" path="/virtual_reference_numbers/{uid}/lock" example="vrn_lock_cooldown_active" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.VirtualReferenceNumbers.LockAsync(
    uid: "<id>",
    body: new PutVirtualReferenceNumbersUidLockRequestBody() {
        LockReason = LockReasonRequest.Admin,
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                             | Type                                                                                                                  | Required                                                                                                              | Description                                                                                                           |
| --------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- |
| `Uid`                                                                                                                 | *string*                                                                                                              | :heavy_check_mark:                                                                                                    | Newline-generated unique id resource specific to the current endpoint                                                 |
| `Body`                                                                                                                | [PutVirtualReferenceNumbersUidLockRequestBody](../../Models/Requests/PutVirtualReferenceNumbersUidLockRequestBody.md) | :heavy_check_mark:                                                                                                    | N/A                                                                                                                   |

### Response

**[PutVirtualReferenceNumbersUidLockResponse](../../Models/Requests/PutVirtualReferenceNumbersUidLockResponse.md)**

### Errors

| Error Type                                                                                | Status Code                                                                               | Content Type                                                                              |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| Newline53.Sdk.Models.Errors.PutVirtualReferenceNumbersUidLockNotFoundException            | 404                                                                                       | application/json                                                                          |
| Newline53.Sdk.Models.Errors.PutVirtualReferenceNumbersUidLockUnprocessableEntityException | 422                                                                                       | application/json                                                                          |
| Newline53.Sdk.Models.Errors.APIException                                                  | 4XX, 5XX                                                                                  | \*/\*                                                                                     |

## Unlock

Unlocks a previously locked Virtual Reference Number, restoring its ability to receive payments and participate in reconciliation workflows.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="put_/virtual_reference_numbers/{uid}/unlock" method="put" path="/virtual_reference_numbers/{uid}/unlock" example="registered" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.VirtualReferenceNumbers.UnlockAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[PutVirtualReferenceNumbersUidUnlockResponse](../../Models/Requests/PutVirtualReferenceNumbersUidUnlockResponse.md)**

### Errors

| Error Type                                                                                  | Status Code                                                                                 | Content Type                                                                                |
| ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| Newline53.Sdk.Models.Errors.PutVirtualReferenceNumbersUidUnlockNotFoundException            | 404                                                                                         | application/json                                                                            |
| Newline53.Sdk.Models.Errors.PutVirtualReferenceNumbersUidUnlockUnprocessableEntityException | 422                                                                                         | application/json                                                                            |
| Newline53.Sdk.Models.Errors.APIException                                                    | 4XX, 5XX                                                                                    | \*/\*                                                                                       |