# Transfers

## Overview

Transfers facilitate the movement of assets between accounts, enabling transactions such as payments and withdrawals.

**Endpoints:**

- GET [List Transfers: GET /transfers](https://developers.newline53.com/reference/get_transfers)

- POST [Initiate a Transfer: POST /transfers](https://developers.newline53.com/reference/post_transfers)

- GET [Get a single Transfer: GET /transfers/{uid}](https://developers.newline53.com/reference/get_transfers-uid)

- PUT [Cancel a Transfer: PUT /transfers/{uid}/cancel](https://developers.newline53.com/reference/put_transfers-uid-cancel)

A Transfer is the Action of moving assets between two Synthetic Accounts. Most asset movement initiated by your application will result in a Transfer. Asset movement is determined by the makeup of assets in both participating accounts, the Synthetic Account Type of the participating accounts, the available Custodial Accounts for all participating Customers, and the overall Program configuration. A Transfer can never be initiated between two external accounts.

### Company ID Behavior

The company_id field is optional when initiating a transfer. However, it becomes required if your organization has multiple company IDs or multiple custodial accounts, to ensure accurate routing of funds. If provided, the value will be validated.

In sandbox environments:

- `company_id` is optional and will be validated if supplied.
- `company_id` and custodial accounts are always in a 1:1 relationship.

> **Note** 
> Any time a Transfer is created, it creates 1+ Transactions, which are returned in the response payload for a successful Transfer. Please note or record these uids, as they will be needed to query the Transaction object and any associated key data points. For instance, Fed IMAD or CHIPS SSN is used for outgoing wires.

### Available Operations

* [List](#list) - List Transfers
* [Create](#create) - Initiate a Transfer
* [Get](#get) - Get a single Transfer
* [Cancel](#cancel) - Cancel a Transfer

## List

Retrieves a list of Transfers filtered by the given parameters. Transfers facilitate the movement of assets between accounts, enabling transactions such as payments and withdrawals.


### Example Usage

<!-- UsageSnippet language="csharp" operationID="listTransfers" method="get" path="/transfers" example="transactions" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

ListTransfersRequest req = new ListTransfersRequest() {
    CustomerUid = "uKxmLxUEiSj5h4M3",
    ExternalUid = "client-generated-id",
    PoolUid = "wTSMX1GubP21ev2h",
    SyntheticAccountUid = "4XkJnsfHsuqrxmeX",
};

var res = await sdk.Transfers.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [ListTransfersRequest](../../Models/Requests/ListTransfersRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[ListTransfersResponse](../../Models/Requests/ListTransfersResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## Create

Attempt to initiate a Transfer between two Synthetic Accounts. Before the Transfer will be initiated, several checks will be performed to ensure there is sufficient balance in the source account and that the initiating Customer has all the necessary access to both Synthetic Accounts.

The Synthetic Accounts allowed in a Transfer request are listed below

- between a liability Synthetic Account in the `general` category and a Synthetic Account in the `ach_external`, `wire_external`, or `instant_payment_external` category
- between two liability Synthetic Accounts in the `general` category that are also owned by the same Customer.

> **Note**
> Please note that if utilizing the Transmitter information, the initiator type should be set to transmitter. If not set, the field defaults to customer and any data provided in that field will be ignored.

### Example Usage: ach

<!-- UsageSnippet language="csharp" operationID="createTransfer" method="post" path="/transfers" example="ach" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateTransferRequest req = new CreateTransferRequest() {
    ExternalUid = "partner-generated-id",
    SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
    DestinationSyntheticAccountUid = "exMDShw6yM3NHLYV",
    InitiatingCustomerUid = "iDtmSA52zRhgN4iy",
    DestinationCustomerUid = "iDtmSA52zRhgN4iy",
    InitiatorType = CreateTransferInitiatorTypeRequest.Customer,
    UsdTransferAmount = "12.34",
    Ach = new CreateTransferAchRequest() {
        OriginatorName = "Mr. Hyyt Meiser",
        CompanyId = "HJK867",
        CompanyDiscretionaryData = "Some data",
        Prenote = false,
        SecCode = CreateTransferSecCodeRequest.Ccd,
        PaymentType = CreateTransferPaymentTypeRequest.S,
        EntryDescription = "ACH Entry",
        ServiceProcessing = CreateTransferServiceProcessingRequest.Standard,
        EffectiveEntryDate = "2023-12-21",
        IdNumber = "4270465600",
        Addenda = "Having said that, this",
    },
};

var res = await sdk.Transfers.CreateAsync(req);

// handle response
```
### Example Usage: ach_transfer

<!-- UsageSnippet language="csharp" operationID="createTransfer" method="post" path="/transfers" example="ach_transfer" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateTransferRequest req = new CreateTransferRequest() {
    ExternalUid = "partner-generated-id",
    SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
    DestinationSyntheticAccountUid = "exMDShw6yM3NHLYV",
    InitiatingCustomerUid = "iDtmSA52zRhgN4iy",
    DestinationCustomerUid = "iDtmSA52zRhgN4iy",
    InitiatorType = CreateTransferInitiatorTypeRequest.Customer,
    UsdTransferAmount = "12.34",
    Ach = new CreateTransferAchRequest() {
        OriginatorName = "J. Fred Muggs",
        CompanyId = "ABC-123456",
        CompanyDiscretionaryData = "ABC.123",
        Prenote = false,
        SecCode = CreateTransferSecCodeRequest.Cie,
        PaymentType = CreateTransferPaymentTypeRequest.St,
        EntryDescription = "ACH Entry",
        ServiceProcessing = CreateTransferServiceProcessingRequest.Sameday,
        EffectiveEntryDate = "2023-12-01",
        IdNumber = "4270465600",
    },
    InstantPayment = new CreateTransferInstantPaymentRequest() {
        InstantPaymentTransmitter = new CreateTransferInstantPaymentTransmitter() {
            Name = "Marge's Roofing Inc",
            TransmitterIdentifier = "123456789012ABC",
            StreetNumber = "123abc",
            Street1 = "Abc St.",
            City = "Chicago",
            State = "IL",
            PostalCode = "60301",
            Country = null,
        },
        Memo = "For the 6-5-23 shipment of pineapple popsicles",
    },
    Wire = new CreateTransferWireRequest() {
        IntermediaryBankAddress = new CreateTransferIntermediaryBankAddressRequest() {
            Line1 = "345 Def Ave",
            Line2 = "San Francisco",
            Line3 = "CA 94016",
            Country = "US",
        },
        IntermediaryBankName = "Fidelity Fiduciary Bank",
        IntermediaryBankRoutingNumber = "923456789",
        WireInstructions = "Send ASAP",
        WireTransmitter = new CreateTransferWireTransmitterRequest() {
            Name = "Marge's Roofing Inc",
            TransmitterIdentifier = "123456789012ABC",
            Line1 = "123 Abc St.",
            Line2 = "Boring, Oregon 97009",
            Line3 = null,
            Country = "US",
        },
    },
};

var res = await sdk.Transfers.CreateAsync(req);

// handle response
```
### Example Usage: instant_payment

<!-- UsageSnippet language="csharp" operationID="createTransfer" method="post" path="/transfers" example="instant_payment" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateTransferRequest req = new CreateTransferRequest() {
    ExternalUid = "partner-generated-id",
    SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
    DestinationSyntheticAccountUid = "exMDShw6yM3NHLYV",
    InitiatingCustomerUid = "iDtmSA52zRhgN4iy",
    DestinationCustomerUid = "iDtmSA52zRhgN4iy",
    InitiatorType = CreateTransferInitiatorTypeRequest.Customer,
    UsdTransferAmount = "12.34",
    InstantPayment = new CreateTransferInstantPaymentRequest() {
        InstantPaymentTransmitter = new CreateTransferInstantPaymentTransmitter() {
            Name = "Royalty Asset Management",
            TransmitterIdentifier = "123456789",
            StreetNumber = "123",
            Street1 = "Abc St.",
            City = "Boring",
            State = "OR",
            PostalCode = "97009",
            Country = null,
        },
        Memo = "To unfreeze the prince's assets",
    },
};

var res = await sdk.Transfers.CreateAsync(req);

// handle response
```
### Example Usage: instant_payment_transfer

<!-- UsageSnippet language="csharp" operationID="createTransfer" method="post" path="/transfers" example="instant_payment_transfer" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateTransferRequest req = new CreateTransferRequest() {
    ExternalUid = "partner-generated-id",
    SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
    DestinationSyntheticAccountUid = "exMDShw6yM3NHLYV",
    InitiatingCustomerUid = "iDtmSA52zRhgN4iy",
    DestinationCustomerUid = "iDtmSA52zRhgN4iy",
    InitiatorType = CreateTransferInitiatorTypeRequest.Customer,
    UsdTransferAmount = "12.34",
    Ach = new CreateTransferAchRequest() {
        OriginatorName = "J. Fred Muggs",
        CompanyId = "ABC-123456",
        CompanyDiscretionaryData = "ABC.123",
        Prenote = false,
        SecCode = CreateTransferSecCodeRequest.Cie,
        PaymentType = CreateTransferPaymentTypeRequest.St,
        EntryDescription = "ACH Entry",
        ServiceProcessing = CreateTransferServiceProcessingRequest.Sameday,
        EffectiveEntryDate = "2023-12-01",
        IdNumber = "4270465600",
    },
    InstantPayment = new CreateTransferInstantPaymentRequest() {
        InstantPaymentTransmitter = new CreateTransferInstantPaymentTransmitter() {
            Name = "Marge's Roofing Inc",
            TransmitterIdentifier = "123456789012ABC",
            StreetNumber = "123abc",
            Street1 = "Abc St.",
            City = "Chicago",
            State = "IL",
            PostalCode = "60301",
            Country = null,
        },
        Memo = "For the 6-5-23 shipment of pineapple popsicles",
    },
    Wire = new CreateTransferWireRequest() {
        IntermediaryBankAddress = new CreateTransferIntermediaryBankAddressRequest() {
            Line1 = "345 Def Ave",
            Line2 = "San Francisco",
            Line3 = "CA 94016",
            Country = "US",
        },
        IntermediaryBankName = "Fidelity Fiduciary Bank",
        IntermediaryBankRoutingNumber = "923456789",
        WireInstructions = "Send ASAP",
        WireTransmitter = new CreateTransferWireTransmitterRequest() {
            Name = "Marge's Roofing Inc",
            TransmitterIdentifier = "123456789012ABC",
            Line1 = "123 Abc St.",
            Line2 = "Boring, Oregon 97009",
            Line3 = null,
            Country = "US",
        },
    },
};

var res = await sdk.Transfers.CreateAsync(req);

// handle response
```
### Example Usage: wire

<!-- UsageSnippet language="csharp" operationID="createTransfer" method="post" path="/transfers" example="wire" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateTransferRequest req = new CreateTransferRequest() {
    ExternalUid = "partner-generated-id",
    SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
    DestinationSyntheticAccountUid = "exMDShw6yM3NHLYV",
    InitiatingCustomerUid = "iDtmSA52zRhgN4iy",
    DestinationCustomerUid = "iDtmSA52zRhgN4iy",
    InitiatorType = CreateTransferInitiatorTypeRequest.Customer,
    UsdTransferAmount = "12.34",
    Wire = new CreateTransferWireRequest() {
        IntermediaryBankAddress = new CreateTransferIntermediaryBankAddressRequest() {
            Line1 = "345 Def Ave",
            Line2 = "San Francisco",
            Line3 = "CA 94016",
            Country = "US",
        },
        IntermediaryBankName = "Fidelity Fiduciary Bank",
        IntermediaryBankRoutingNumber = "923456789",
        WireInstructions = "Please send ASAP",
        WireTransmitter = new CreateTransferWireTransmitterRequest() {
            Name = "Top Tier Tacos",
            TransmitterIdentifier = "123456789",
            Line1 = "123 Abc St.",
            Country = "US",
        },
    },
};

var res = await sdk.Transfers.CreateAsync(req);

// handle response
```
### Example Usage: wire_transfer

<!-- UsageSnippet language="csharp" operationID="createTransfer" method="post" path="/transfers" example="wire_transfer" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateTransferRequest req = new CreateTransferRequest() {
    ExternalUid = "partner-generated-id",
    SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
    DestinationSyntheticAccountUid = "exMDShw6yM3NHLYV",
    InitiatingCustomerUid = "iDtmSA52zRhgN4iy",
    DestinationCustomerUid = "iDtmSA52zRhgN4iy",
    InitiatorType = CreateTransferInitiatorTypeRequest.Customer,
    UsdTransferAmount = "12.34",
    Ach = new CreateTransferAchRequest() {
        OriginatorName = "J. Fred Muggs",
        CompanyId = "ABC-123456",
        CompanyDiscretionaryData = "ABC.123",
        Prenote = false,
        SecCode = CreateTransferSecCodeRequest.Cie,
        PaymentType = CreateTransferPaymentTypeRequest.St,
        EntryDescription = "ACH Entry",
        ServiceProcessing = CreateTransferServiceProcessingRequest.Sameday,
        EffectiveEntryDate = "2023-12-01",
        IdNumber = "4270465600",
    },
    InstantPayment = new CreateTransferInstantPaymentRequest() {
        InstantPaymentTransmitter = new CreateTransferInstantPaymentTransmitter() {
            Name = "Marge's Roofing Inc",
            TransmitterIdentifier = "123456789012ABC",
            StreetNumber = "123abc",
            Street1 = "Abc St.",
            City = "Chicago",
            State = "IL",
            PostalCode = "60301",
            Country = null,
        },
        Memo = "For the 6-5-23 shipment of pineapple popsicles",
    },
    Wire = new CreateTransferWireRequest() {
        IntermediaryBankAddress = new CreateTransferIntermediaryBankAddressRequest() {
            Line1 = "345 Def Ave",
            Line2 = "San Francisco",
            Line3 = "CA 94016",
            Country = "US",
        },
        IntermediaryBankName = "Fidelity Fiduciary Bank",
        IntermediaryBankRoutingNumber = "923456789",
        WireInstructions = "Send ASAP",
        WireTransmitter = new CreateTransferWireTransmitterRequest() {
            Name = "Marge's Roofing Inc",
            TransmitterIdentifier = "123456789012ABC",
            Line1 = "123 Abc St.",
            Line2 = "Boring, Oregon 97009",
            Line3 = null,
            Country = "US",
        },
    },
};

var res = await sdk.Transfers.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `request`                                                               | [CreateTransferRequest](../../Models/Requests/CreateTransferRequest.md) | :heavy_check_mark:                                                      | The request object to use for the request.                              |

### Response

**[CreateTransferResponse](../../Models/Requests/CreateTransferResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## Get

Retrieves a single Transfer resource along with its details, including status, participating accounts, and associated Transactions.

Filter parameters are not case sensitive but will only return exact matches.

### Example Usage: ach_transfer

<!-- UsageSnippet language="csharp" operationID="getTransfer" method="get" path="/transfers/{uid}" example="ach_transfer" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transfers.GetAsync(uid: "<id>");

// handle response
```
### Example Usage: canceled_transfer

<!-- UsageSnippet language="csharp" operationID="getTransfer" method="get" path="/transfers/{uid}" example="canceled_transfer" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transfers.GetAsync(uid: "<id>");

// handle response
```
### Example Usage: instant_payment_transfer

<!-- UsageSnippet language="csharp" operationID="getTransfer" method="get" path="/transfers/{uid}" example="instant_payment_transfer" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transfers.GetAsync(uid: "<id>");

// handle response
```
### Example Usage: wire_transfer

<!-- UsageSnippet language="csharp" operationID="getTransfer" method="get" path="/transfers/{uid}" example="wire_transfer" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transfers.GetAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetTransferResponse](../../Models/Requests/GetTransferResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## Cancel

Transfers must be canceled by the originating Customer (or Authorized Representative).

Transfers can only enter the canceled state if Newline receives a request while the Transfer is in `queued` or `pending states`.

A cancellation request during the `pending` state is not guaranteed, as this state may include payment execution. At that stage, a cancel request will result in an error.

### Example Usage: canceled_transfer

<!-- UsageSnippet language="csharp" operationID="put_/transfers/{uid}/cancel" method="put" path="/transfers/{uid}/cancel" example="canceled_transfer" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transfers.CancelAsync(
    uid: "<id>",
    body: new PutTransfersUidCancelRequestBody() {
        AuthorizedRepresentativeName = "Swee'Pea",
        CancellationReason = "Transfer submitted by accident",
    }
);

// handle response
```
### Example Usage: invalid_transfer_cancellation

<!-- UsageSnippet language="csharp" operationID="put_/transfers/{uid}/cancel" method="put" path="/transfers/{uid}/cancel" example="invalid_transfer_cancellation" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transfers.CancelAsync(
    uid: "<id>",
    body: new PutTransfersUidCancelRequestBody() {
        AuthorizedRepresentativeName = "Swee'Pea",
        CancellationReason = "Transfer submitted by accident",
    }
);

// handle response
```
### Example Usage: transfer_cancellation_error

<!-- UsageSnippet language="csharp" operationID="put_/transfers/{uid}/cancel" method="put" path="/transfers/{uid}/cancel" example="transfer_cancellation_error" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Transfers.CancelAsync(
    uid: "<id>",
    body: new PutTransfersUidCancelRequestBody() {
        AuthorizedRepresentativeName = "Swee'Pea",
        CancellationReason = "Transfer submitted by accident",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                     | Type                                                                                          | Required                                                                                      | Description                                                                                   |
| --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- |
| `Uid`                                                                                         | *string*                                                                                      | :heavy_check_mark:                                                                            | Newline-generated unique id resource specific to the current endpoint                         |
| `Body`                                                                                        | [PutTransfersUidCancelRequestBody](../../Models/Requests/PutTransfersUidCancelRequestBody.md) | :heavy_check_mark:                                                                            | N/A                                                                                           |

### Response

**[PutTransfersUidCancelResponse](../../Models/Requests/PutTransfersUidCancelResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| Newline53.Sdk.Models.Errors.PutTransfersUidCancelBadRequestException          | 400                                                                           | application/json                                                              |
| Newline53.Sdk.Models.Errors.PutTransfersUidCancelUnprocessableEntityException | 422                                                                           | application/json                                                              |
| Newline53.Sdk.Models.Errors.APIException                                      | 4XX, 5XX                                                                      | \*/\*                                                                         |