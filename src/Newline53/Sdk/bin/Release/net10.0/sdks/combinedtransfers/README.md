# CombinedTransfers

## Overview

### Available Operations

* [List](#list) - List Combined Transfers
* [Create](#create) - Create a new Combined Transfer
* [Get](#get) - Get a single Combined Transfer

## List

Retrieves a list of Combined Transfers. These represent transactions where both a counterparty Synthetic Account and a Transfer were created in a single API call. You can filter results by status and other parameters.


### Example Usage

<!-- UsageSnippet language="csharp" operationID="get_/combined_transfers" method="get" path="/combined_transfers" example="combined_transfers_list" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;
using System;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

GetCombinedTransfersRequest req = new GetCombinedTransfersRequest() {
    CreatedAtAfter = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    CreatedAtBefore = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    ExternalUid = "client-generated-id",
    Status = GetCombinedTransfersQueryParamStatus.Completed,
    SyntheticAccountExternalUid = "client-generated-id",
    SyntheticAccountPoolUid = "wTSMX1GubP21ev2h",
    SyntheticAccountUid = "7UvkHn3Ss9AbWe2c",
    TransferCustomerUid = "wTSMX1GubP21ev2h",
    TransferExternalUid = "client-generated-id",
    TransferUid = "7UvkHn3Ss9AbWe2c",
};

var res = await sdk.CombinedTransfers.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `request`                                                                           | [GetCombinedTransfersRequest](../../Models/Requests/GetCombinedTransfersRequest.md) | :heavy_check_mark:                                                                  | The request object to use for the request.                                          |

### Response

**[GetCombinedTransfersResponse](../../Models/Requests/GetCombinedTransfersResponse.md)**

### Errors

| Error Type                                                                   | Status Code                                                                  | Content Type                                                                 |
| ---------------------------------------------------------------------------- | ---------------------------------------------------------------------------- | ---------------------------------------------------------------------------- |
| Newline53.Sdk.Models.Errors.GetCombinedTransfersForbiddenException           | 403                                                                          | application/json                                                             |
| Newline53.Sdk.Models.Errors.GetCombinedTransfersUnprocessableEntityException | 422                                                                          | application/json                                                             |
| Newline53.Sdk.Models.Errors.APIException                                     | 4XX, 5XX                                                                     | \*/\*                                                                        |

## Create

Creates a Combined Transfer by simultaneously creating a counterparty Synthetic Account and initiating a Transfer. This streamlines asset movement by reducing the number of steps required to set up and execute a transaction.


### Example Usage: ach_transfer_to_existing_account

<!-- UsageSnippet language="csharp" operationID="post_/combined_transfers" method="post" path="/combined_transfers" example="ach_transfer_to_existing_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostCombinedTransfersRequest req = new PostCombinedTransfersRequest() {
    SyntheticAccount = new SyntheticAccountRequest() {
        ExternalUid = "partner-generated-id",
        Name = "New Resource Name",
        PoolUid = "kaxHFJnWvJxRJZxq",
        SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
    },
    Transfer = new TransferRequest() {
        SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
        DestinationSyntheticAccountUid = "beHyJNeBU65Xv8LK",
        InitiatingCustomerUid = "axz9sbUgRVu5wqbw",
        InitiatorType = PostCombinedTransfersInitiatorType.Customer,
        UsdTransferAmount = "12.34",
        Ach = new TransferAch() {
            OriginatorName = "J. Fred Muggs",
            SecCode = PostCombinedTransfersSecCode.Cie,
            EntryDescription = "ACH Entry",
            ServiceProcessing = PostCombinedTransfersServiceProcessing.Sameday,
            EffectiveEntryDate = "2023-12-01",
        },
    },
};

var res = await sdk.CombinedTransfers.CreateAsync(req);

// handle response
```
### Example Usage: ach_transfer_to_new_account

<!-- UsageSnippet language="csharp" operationID="post_/combined_transfers" method="post" path="/combined_transfers" example="ach_transfer_to_new_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostCombinedTransfersRequest req = new PostCombinedTransfersRequest() {
    SyntheticAccount = new SyntheticAccountRequest() {
        ExternalUid = "abcd12345",
        Name = "Spinach Fund",
        PoolUid = "axz9sbUgRVu5wqbw",
        SyntheticAccountTypeUid = "UyjH72G9KAhmbpNS",
        RoutingNumber = "04200031",
        AccountNumber = "1234567890",
        Ach = new SyntheticAccountAch() {
            AccountType = PostCombinedTransfersAccountType.Checking,
            CounterpartyName = "awesome counterparty",
        },
    },
    Transfer = new TransferRequest() {
        SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
        DestinationSyntheticAccountUid = "beHyJNeBU65Xv8LK",
        InitiatingCustomerUid = "axz9sbUgRVu5wqbw",
        InitiatorType = PostCombinedTransfersInitiatorType.Customer,
        UsdTransferAmount = "12.34",
        Ach = new TransferAch() {
            OriginatorName = "J. Fred Muggs",
            SecCode = PostCombinedTransfersSecCode.Cie,
            EntryDescription = "ACH Entry",
            ServiceProcessing = PostCombinedTransfersServiceProcessing.Sameday,
            EffectiveEntryDate = "2023-12-01",
        },
    },
};

var res = await sdk.CombinedTransfers.CreateAsync(req);

// handle response
```
### Example Usage: combined_transfer_creation_error

<!-- UsageSnippet language="csharp" operationID="post_/combined_transfers" method="post" path="/combined_transfers" example="combined_transfer_creation_error" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostCombinedTransfersRequest req = new PostCombinedTransfersRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    SyntheticAccount = new SyntheticAccountRequest() {
        ExternalUid = "partner-generated-id",
        Name = "New Resource Name",
        PoolUid = "kaxHFJnWvJxRJZxq",
        SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
        RoutingNumber = "123456789",
        AccountNumber = "123456789012",
        ExternalProcessorToken = "processor-sandbox-96d86f35-ef58-4e4a-826f-4870b5d677f2",
        Ach = new SyntheticAccountAch() {
            AccountType = PostCombinedTransfersAccountType.Checking,
            CounterpartyName = "Thelma's Flooring LLC",
        },
        InstantPayment = new SyntheticAccountInstantPayment() {
            CounterpartyAddress = new PostCombinedTransfersInstantPaymentCounterpartyAddress() {
                StreetNumber = "123abc",
                Street1 = "Abc St.",
                Street2 = "Suite 4A",
                City = "Chicago",
                State = "IL",
                PostalCode = "60301",
                Country = null,
            },
            CounterpartyName = "Marge's Roofing Inc",
            Email = "payments@veryexcellentbusiness.com",
            Phone = "5555551212",
        },
        Wire = new SyntheticAccountWire() {
            CounterpartyAddress = PostCombinedTransfersCounterpartyAddressUnion.CreateCounterpartyAddressSyntheticAccountUnstructuredAddress(
                new CounterpartyAddressSyntheticAccountUnstructuredAddress() {
                    Line1 = "234 Xyz Rd",
                    Line2 = "APT 5",
                    Line3 = "Boston, MA 02110",
                    Country = "US",
                }
            ),
            CounterpartyName = "Marge's Roofing Inc",
            CounterpartyBankAddress = new SyntheticAccountCounterpartyBankAddressUnstructuredAddress() {
                Line1 = "123 Abc St.",
                Line2 = "Boring, Oregon 97009",
                Line3 = null,
                Country = null,
            },
            CounterpartyBankName = "East West Regional Bank",
        },
    },
    Transfer = new TransferRequest() {
        ExternalUid = "partner-generated-id",
        SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
        DestinationSyntheticAccountUid = "exMDShw6yM3NHLYV",
        InitiatingCustomerUid = "iDtmSA52zRhgN4iy",
        DestinationCustomerUid = "iDtmSA52zRhgN4iy",
        InitiatorType = PostCombinedTransfersInitiatorType.Customer,
        UsdTransferAmount = "12.34",
        Ach = new TransferAch() {
            OriginatorName = "J. Fred Muggs",
            CompanyId = "ABC-123456",
            CompanyDiscretionaryData = "ABC.123",
            Prenote = false,
            SecCode = PostCombinedTransfersSecCode.Cie,
            PaymentType = PostCombinedTransfersPaymentType.St,
            EntryDescription = "ACH Entry",
            ServiceProcessing = PostCombinedTransfersServiceProcessing.Sameday,
            EffectiveEntryDate = "2023-12-01",
            IdNumber = "4270465600",
        },
        InstantPayment = new TransferInstantPayment() {
            InstantPaymentTransmitter = new PostCombinedTransfersInstantPaymentTransmitter() {
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
            PurposeOfPayment = PostCombinedTransfersPurposeOfPayment.Payr,
        },
        Wire = new TransferWire() {
            IntermediaryBankAddress = new TransferIntermediaryBankAddressUnstructuredAddress() {
                Line1 = "345 Def Ave",
                Line2 = "San Francisco",
                Line3 = "CA 94016",
                Country = "US",
            },
            IntermediaryBankName = "Fidelity Fiduciary Bank",
            IntermediaryBankRoutingNumber = "923456789",
            WireInstructions = "Send ASAP",
            WireTransmitter = PostCombinedTransfersWireTransmitter.CreateWireTransmitterTransferUnstructuredAddress(
                new WireTransmitterTransferUnstructuredAddress() {
                    Line1 = "123 Abc St.",
                    Line2 = "Boring, Oregon 97009",
                    Line3 = null,
                    Country = "US",
                    Name = "Marge's Roofing Inc",
                    TransmitterIdentifier = "123456789012ABC",
                }
            ),
        },
    },
};

var res = await sdk.CombinedTransfers.CreateAsync(req);

// handle response
```
### Example Usage: combined_transfer_external_uid_taken

<!-- UsageSnippet language="csharp" operationID="post_/combined_transfers" method="post" path="/combined_transfers" example="combined_transfer_external_uid_taken" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostCombinedTransfersRequest req = new PostCombinedTransfersRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    SyntheticAccount = new SyntheticAccountRequest() {
        ExternalUid = "partner-generated-id",
        Name = "New Resource Name",
        PoolUid = "kaxHFJnWvJxRJZxq",
        SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
        RoutingNumber = "123456789",
        AccountNumber = "123456789012",
        ExternalProcessorToken = "processor-sandbox-96d86f35-ef58-4e4a-826f-4870b5d677f2",
        Ach = new SyntheticAccountAch() {
            AccountType = PostCombinedTransfersAccountType.Checking,
            CounterpartyName = "Thelma's Flooring LLC",
        },
        InstantPayment = new SyntheticAccountInstantPayment() {
            CounterpartyAddress = new PostCombinedTransfersInstantPaymentCounterpartyAddress() {
                StreetNumber = "123abc",
                Street1 = "Abc St.",
                Street2 = "Suite 4A",
                City = "Chicago",
                State = "IL",
                PostalCode = "60301",
                Country = null,
            },
            CounterpartyName = "Marge's Roofing Inc",
            Email = "payments@veryexcellentbusiness.com",
            Phone = "5555551212",
        },
        Wire = new SyntheticAccountWire() {
            CounterpartyAddress = PostCombinedTransfersCounterpartyAddressUnion.CreateCounterpartyAddressSyntheticAccountUnstructuredAddress(
                new CounterpartyAddressSyntheticAccountUnstructuredAddress() {
                    Line1 = "234 Xyz Rd",
                    Line2 = "APT 5",
                    Line3 = "Boston, MA 02110",
                    Country = "US",
                }
            ),
            CounterpartyName = "Marge's Roofing Inc",
            CounterpartyBankAddress = new SyntheticAccountCounterpartyBankAddressUnstructuredAddress() {
                Line1 = "123 Abc St.",
                Line2 = "Boring, Oregon 97009",
                Line3 = null,
                Country = null,
            },
            CounterpartyBankName = "East West Regional Bank",
        },
    },
    Transfer = new TransferRequest() {
        ExternalUid = "partner-generated-id",
        SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
        DestinationSyntheticAccountUid = "exMDShw6yM3NHLYV",
        InitiatingCustomerUid = "iDtmSA52zRhgN4iy",
        DestinationCustomerUid = "iDtmSA52zRhgN4iy",
        InitiatorType = PostCombinedTransfersInitiatorType.Customer,
        UsdTransferAmount = "12.34",
        Ach = new TransferAch() {
            OriginatorName = "J. Fred Muggs",
            CompanyId = "ABC-123456",
            CompanyDiscretionaryData = "ABC.123",
            Prenote = false,
            SecCode = PostCombinedTransfersSecCode.Cie,
            PaymentType = PostCombinedTransfersPaymentType.St,
            EntryDescription = "ACH Entry",
            ServiceProcessing = PostCombinedTransfersServiceProcessing.Sameday,
            EffectiveEntryDate = "2023-12-01",
            IdNumber = "4270465600",
        },
        InstantPayment = new TransferInstantPayment() {
            InstantPaymentTransmitter = new PostCombinedTransfersInstantPaymentTransmitter() {
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
            PurposeOfPayment = PostCombinedTransfersPurposeOfPayment.Payr,
        },
        Wire = new TransferWire() {
            IntermediaryBankAddress = new TransferIntermediaryBankAddressUnstructuredAddress() {
                Line1 = "345 Def Ave",
                Line2 = "San Francisco",
                Line3 = "CA 94016",
                Country = "US",
            },
            IntermediaryBankName = "Fidelity Fiduciary Bank",
            IntermediaryBankRoutingNumber = "923456789",
            WireInstructions = "Send ASAP",
            WireTransmitter = PostCombinedTransfersWireTransmitter.CreateWireTransmitterTransferUnstructuredAddress(
                new WireTransmitterTransferUnstructuredAddress() {
                    Line1 = "123 Abc St.",
                    Line2 = "Boring, Oregon 97009",
                    Line3 = null,
                    Country = "US",
                    Name = "Marge's Roofing Inc",
                    TransmitterIdentifier = "123456789012ABC",
                }
            ),
        },
    },
};

var res = await sdk.CombinedTransfers.CreateAsync(req);

// handle response
```
### Example Usage: combined_transfers_disabled

<!-- UsageSnippet language="csharp" operationID="post_/combined_transfers" method="post" path="/combined_transfers" example="combined_transfers_disabled" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostCombinedTransfersRequest req = new PostCombinedTransfersRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    SyntheticAccount = new SyntheticAccountRequest() {
        ExternalUid = "partner-generated-id",
        Name = "New Resource Name",
        PoolUid = "kaxHFJnWvJxRJZxq",
        SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
        RoutingNumber = "123456789",
        AccountNumber = "123456789012",
        ExternalProcessorToken = "processor-sandbox-96d86f35-ef58-4e4a-826f-4870b5d677f2",
        Ach = new SyntheticAccountAch() {
            AccountType = PostCombinedTransfersAccountType.Checking,
            CounterpartyName = "Thelma's Flooring LLC",
        },
        InstantPayment = new SyntheticAccountInstantPayment() {
            CounterpartyAddress = new PostCombinedTransfersInstantPaymentCounterpartyAddress() {
                StreetNumber = "123abc",
                Street1 = "Abc St.",
                Street2 = "Suite 4A",
                City = "Chicago",
                State = "IL",
                PostalCode = "60301",
                Country = null,
            },
            CounterpartyName = "Marge's Roofing Inc",
            Email = "payments@veryexcellentbusiness.com",
            Phone = "5555551212",
        },
        Wire = new SyntheticAccountWire() {
            CounterpartyAddress = PostCombinedTransfersCounterpartyAddressUnion.CreateCounterpartyAddressSyntheticAccountUnstructuredAddress(
                new CounterpartyAddressSyntheticAccountUnstructuredAddress() {
                    Line1 = "234 Xyz Rd",
                    Line2 = "APT 5",
                    Line3 = "Boston, MA 02110",
                    Country = "US",
                }
            ),
            CounterpartyName = "Marge's Roofing Inc",
            CounterpartyBankAddress = new SyntheticAccountCounterpartyBankAddressUnstructuredAddress() {
                Line1 = "123 Abc St.",
                Line2 = "Boring, Oregon 97009",
                Line3 = null,
                Country = null,
            },
            CounterpartyBankName = "East West Regional Bank",
        },
    },
    Transfer = new TransferRequest() {
        ExternalUid = "partner-generated-id",
        SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
        DestinationSyntheticAccountUid = "exMDShw6yM3NHLYV",
        InitiatingCustomerUid = "iDtmSA52zRhgN4iy",
        DestinationCustomerUid = "iDtmSA52zRhgN4iy",
        InitiatorType = PostCombinedTransfersInitiatorType.Customer,
        UsdTransferAmount = "12.34",
        Ach = new TransferAch() {
            OriginatorName = "J. Fred Muggs",
            CompanyId = "ABC-123456",
            CompanyDiscretionaryData = "ABC.123",
            Prenote = false,
            SecCode = PostCombinedTransfersSecCode.Cie,
            PaymentType = PostCombinedTransfersPaymentType.St,
            EntryDescription = "ACH Entry",
            ServiceProcessing = PostCombinedTransfersServiceProcessing.Sameday,
            EffectiveEntryDate = "2023-12-01",
            IdNumber = "4270465600",
        },
        InstantPayment = new TransferInstantPayment() {
            InstantPaymentTransmitter = new PostCombinedTransfersInstantPaymentTransmitter() {
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
            PurposeOfPayment = PostCombinedTransfersPurposeOfPayment.Payr,
        },
        Wire = new TransferWire() {
            IntermediaryBankAddress = new TransferIntermediaryBankAddressUnstructuredAddress() {
                Line1 = "345 Def Ave",
                Line2 = "San Francisco",
                Line3 = "CA 94016",
                Country = "US",
            },
            IntermediaryBankName = "Fidelity Fiduciary Bank",
            IntermediaryBankRoutingNumber = "923456789",
            WireInstructions = "Send ASAP",
            WireTransmitter = PostCombinedTransfersWireTransmitter.CreateWireTransmitterTransferUnstructuredAddress(
                new WireTransmitterTransferUnstructuredAddress() {
                    Line1 = "123 Abc St.",
                    Line2 = "Boring, Oregon 97009",
                    Line3 = null,
                    Country = "US",
                    Name = "Marge's Roofing Inc",
                    TransmitterIdentifier = "123456789012ABC",
                }
            ),
        },
    },
};

var res = await sdk.CombinedTransfers.CreateAsync(req);

// handle response
```
### Example Usage: instant_payment_transfer_to_existing_account

<!-- UsageSnippet language="csharp" operationID="post_/combined_transfers" method="post" path="/combined_transfers" example="instant_payment_transfer_to_existing_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostCombinedTransfersRequest req = new PostCombinedTransfersRequest() {
    SyntheticAccount = new SyntheticAccountRequest() {
        ExternalUid = "partner-generated-id",
        Name = "New Resource Name",
        PoolUid = "kaxHFJnWvJxRJZxq",
        SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
    },
    Transfer = new TransferRequest() {
        SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
        DestinationSyntheticAccountUid = "beHyJNeBU65Xv8LK",
        InitiatingCustomerUid = "axz9sbUgRVu5wqbw",
        InitiatorType = PostCombinedTransfersInitiatorType.Customer,
        UsdTransferAmount = "12.34",
        InstantPayment = new TransferInstantPayment() {
            InstantPaymentTransmitter = new PostCombinedTransfersInstantPaymentTransmitter() {
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
    },
};

var res = await sdk.CombinedTransfers.CreateAsync(req);

// handle response
```
### Example Usage: instant_payment_transfer_to_new_account

<!-- UsageSnippet language="csharp" operationID="post_/combined_transfers" method="post" path="/combined_transfers" example="instant_payment_transfer_to_new_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostCombinedTransfersRequest req = new PostCombinedTransfersRequest() {
    SyntheticAccount = new SyntheticAccountRequest() {
        ExternalUid = "abcd12345",
        Name = "Spinach Fund",
        PoolUid = "axz9sbUgRVu5wqbw",
        SyntheticAccountTypeUid = "UyjH72G9KAhmbpNS",
        RoutingNumber = "04200031",
        AccountNumber = "1234567890",
        InstantPayment = new SyntheticAccountInstantPayment() {
            CounterpartyAddress = new PostCombinedTransfersInstantPaymentCounterpartyAddress() {
                StreetNumber = "123",
                Street1 = "Main street",
                City = "Brooklyn",
                State = "IA",
                PostalCode = "12345-6789",
                Country = "US",
            },
            CounterpartyName = "awesome counterparty",
            Email = "address@domain.com",
            Phone = "2121112233",
        },
    },
    Transfer = new TransferRequest() {
        SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
        DestinationSyntheticAccountUid = "beHyJNeBU65Xv8LK",
        InitiatingCustomerUid = "axz9sbUgRVu5wqbw",
        InitiatorType = PostCombinedTransfersInitiatorType.Customer,
        UsdTransferAmount = "12.34",
        InstantPayment = new TransferInstantPayment() {
            InstantPaymentTransmitter = new PostCombinedTransfersInstantPaymentTransmitter() {
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
    },
};

var res = await sdk.CombinedTransfers.CreateAsync(req);

// handle response
```
### Example Usage: queued

<!-- UsageSnippet language="csharp" operationID="post_/combined_transfers" method="post" path="/combined_transfers" example="queued" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostCombinedTransfersRequest req = new PostCombinedTransfersRequest() {
    ExternalUid = "YrfDrfVRgpPgnhF5",
    SyntheticAccount = new SyntheticAccountRequest() {
        ExternalUid = "partner-generated-id",
        Name = "New Resource Name",
        PoolUid = "kaxHFJnWvJxRJZxq",
        SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
        RoutingNumber = "123456789",
        AccountNumber = "123456789012",
        ExternalProcessorToken = "processor-sandbox-96d86f35-ef58-4e4a-826f-4870b5d677f2",
        Ach = new SyntheticAccountAch() {
            AccountType = PostCombinedTransfersAccountType.Checking,
            CounterpartyName = "Thelma's Flooring LLC",
        },
        InstantPayment = new SyntheticAccountInstantPayment() {
            CounterpartyAddress = new PostCombinedTransfersInstantPaymentCounterpartyAddress() {
                StreetNumber = "123abc",
                Street1 = "Abc St.",
                Street2 = "Suite 4A",
                City = "Chicago",
                State = "IL",
                PostalCode = "60301",
                Country = null,
            },
            CounterpartyName = "Marge's Roofing Inc",
            Email = "payments@veryexcellentbusiness.com",
            Phone = "5555551212",
        },
        Wire = new SyntheticAccountWire() {
            CounterpartyAddress = PostCombinedTransfersCounterpartyAddressUnion.CreateCounterpartyAddressSyntheticAccountUnstructuredAddress(
                new CounterpartyAddressSyntheticAccountUnstructuredAddress() {
                    Line1 = "234 Xyz Rd",
                    Line2 = "APT 5",
                    Line3 = "Boston, MA 02110",
                    Country = "US",
                }
            ),
            CounterpartyName = "Marge's Roofing Inc",
            CounterpartyBankAddress = new SyntheticAccountCounterpartyBankAddressUnstructuredAddress() {
                Line1 = "123 Abc St.",
                Line2 = "Boring, Oregon 97009",
                Line3 = null,
                Country = null,
            },
            CounterpartyBankName = "East West Regional Bank",
        },
    },
    Transfer = new TransferRequest() {
        ExternalUid = "partner-generated-id",
        SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
        DestinationSyntheticAccountUid = "exMDShw6yM3NHLYV",
        InitiatingCustomerUid = "iDtmSA52zRhgN4iy",
        DestinationCustomerUid = "iDtmSA52zRhgN4iy",
        InitiatorType = PostCombinedTransfersInitiatorType.Customer,
        UsdTransferAmount = "12.34",
        Ach = new TransferAch() {
            OriginatorName = "J. Fred Muggs",
            CompanyId = "ABC-123456",
            CompanyDiscretionaryData = "ABC.123",
            Prenote = false,
            SecCode = PostCombinedTransfersSecCode.Cie,
            PaymentType = PostCombinedTransfersPaymentType.St,
            EntryDescription = "ACH Entry",
            ServiceProcessing = PostCombinedTransfersServiceProcessing.Sameday,
            EffectiveEntryDate = "2023-12-01",
            IdNumber = "4270465600",
        },
        InstantPayment = new TransferInstantPayment() {
            InstantPaymentTransmitter = new PostCombinedTransfersInstantPaymentTransmitter() {
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
            PurposeOfPayment = PostCombinedTransfersPurposeOfPayment.Payr,
        },
        Wire = new TransferWire() {
            IntermediaryBankAddress = new TransferIntermediaryBankAddressUnstructuredAddress() {
                Line1 = "345 Def Ave",
                Line2 = "San Francisco",
                Line3 = "CA 94016",
                Country = "US",
            },
            IntermediaryBankName = "Fidelity Fiduciary Bank",
            IntermediaryBankRoutingNumber = "923456789",
            WireInstructions = "Send ASAP",
            WireTransmitter = PostCombinedTransfersWireTransmitter.CreateWireTransmitterTransferUnstructuredAddress(
                new WireTransmitterTransferUnstructuredAddress() {
                    Line1 = "123 Abc St.",
                    Line2 = "Boring, Oregon 97009",
                    Line3 = null,
                    Country = "US",
                    Name = "Marge's Roofing Inc",
                    TransmitterIdentifier = "123456789012ABC",
                }
            ),
        },
    },
};

var res = await sdk.CombinedTransfers.CreateAsync(req);

// handle response
```
### Example Usage: wire_transfer_to_existing_account

<!-- UsageSnippet language="csharp" operationID="post_/combined_transfers" method="post" path="/combined_transfers" example="wire_transfer_to_existing_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostCombinedTransfersRequest req = new PostCombinedTransfersRequest() {
    SyntheticAccount = new SyntheticAccountRequest() {
        ExternalUid = "partner-generated-id",
        Name = "New Resource Name",
        PoolUid = "kaxHFJnWvJxRJZxq",
        SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
    },
    Transfer = new TransferRequest() {
        SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
        DestinationSyntheticAccountUid = "beHyJNeBU65Xv8LK",
        InitiatingCustomerUid = "axz9sbUgRVu5wqbw",
        InitiatorType = PostCombinedTransfersInitiatorType.Customer,
        UsdTransferAmount = "12.34",
        Wire = new TransferWire() {
            IntermediaryBankAddress = new TransferIntermediaryBankAddressUnstructuredAddress() {
                Line1 = "123 Main St",
                Line2 = "Brooklyn NY",
                Country = "US",
            },
            IntermediaryBankName = "Big Bank Inc",
            IntermediaryBankRoutingNumber = "123456789",
            WireTransmitter = PostCombinedTransfersWireTransmitter.CreateTransferStructuredAddress(
                new TransferStructuredAddress() {
                    BuildingNumber = "456",
                    StreetName = "Second St",
                    City = "Queens",
                    State = "NY",
                    Country = "US",
                    Name = "Bunker LLC",
                    TransmitterIdentifier = "1234567890",
                }
            ),
        },
    },
};

var res = await sdk.CombinedTransfers.CreateAsync(req);

// handle response
```
### Example Usage: wire_transfer_to_new_account

<!-- UsageSnippet language="csharp" operationID="post_/combined_transfers" method="post" path="/combined_transfers" example="wire_transfer_to_new_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

PostCombinedTransfersRequest req = new PostCombinedTransfersRequest() {
    SyntheticAccount = new SyntheticAccountRequest() {
        ExternalUid = "abcd12345",
        Name = "Spinach Fund",
        PoolUid = "axz9sbUgRVu5wqbw",
        SyntheticAccountTypeUid = "UyjH72G9KAhmbpNS",
        RoutingNumber = "04200031",
        AccountNumber = "1234567890",
        Wire = new SyntheticAccountWire() {
            CounterpartyName = "Awesome Counterparty",
            CounterpartyBankName = "Biggest Bank Inc",
        },
    },
    Transfer = new TransferRequest() {
        SourceSyntheticAccountUid = "4XkJnsfHsuqrxmeX",
        DestinationSyntheticAccountUid = "beHyJNeBU65Xv8LK",
        InitiatingCustomerUid = "axz9sbUgRVu5wqbw",
        InitiatorType = PostCombinedTransfersInitiatorType.Customer,
        UsdTransferAmount = "12.34",
        Wire = new TransferWire() {
            IntermediaryBankAddress = new TransferIntermediaryBankAddressUnstructuredAddress() {
                Line1 = "123 Main St",
                Line2 = "Brooklyn NY",
                Country = "US",
            },
            IntermediaryBankName = "Big Bank Inc",
            IntermediaryBankRoutingNumber = "123456789",
            WireTransmitter = PostCombinedTransfersWireTransmitter.CreateTransferStructuredAddress(
                new TransferStructuredAddress() {
                    BuildingNumber = "456",
                    StreetName = "Second St",
                    City = "Queens",
                    State = "NY",
                    Country = "US",
                    Name = "Bunker LLC",
                    TransmitterIdentifier = "1234567890",
                }
            ),
        },
    },
};

var res = await sdk.CombinedTransfers.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                             | Type                                                                                  | Required                                                                              | Description                                                                           |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `request`                                                                             | [PostCombinedTransfersRequest](../../Models/Requests/PostCombinedTransfersRequest.md) | :heavy_check_mark:                                                                    | The request object to use for the request.                                            |

### Response

**[PostCombinedTransfersResponse](../../Models/Requests/PostCombinedTransfersResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| Newline53.Sdk.Models.Errors.PostCombinedTransfersForbiddenException           | 403                                                                           | application/json                                                              |
| Newline53.Sdk.Models.Errors.PostCombinedTransfersUnprocessableEntityException | 422                                                                           | application/json                                                              |
| Newline53.Sdk.Models.Errors.APIException                                      | 4XX, 5XX                                                                      | \*/\*                                                                         |

## Get

Retrieves details about a specific Combined Transfer, including the status, participating accounts, and associated metadata. Statuses include `queued`, `pending`, `failed`, and `completed`.

### Example Usage: completed

<!-- UsageSnippet language="csharp" operationID="get_/combined_transfers/{uid}" method="get" path="/combined_transfers/{uid}" example="completed" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.CombinedTransfers.GetAsync(uid: "<id>");

// handle response
```
### Example Usage: failed

<!-- UsageSnippet language="csharp" operationID="get_/combined_transfers/{uid}" method="get" path="/combined_transfers/{uid}" example="failed" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.CombinedTransfers.GetAsync(uid: "<id>");

// handle response
```
### Example Usage: pending

<!-- UsageSnippet language="csharp" operationID="get_/combined_transfers/{uid}" method="get" path="/combined_transfers/{uid}" example="pending" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.CombinedTransfers.GetAsync(uid: "<id>");

// handle response
```
### Example Usage: queued

<!-- UsageSnippet language="csharp" operationID="get_/combined_transfers/{uid}" method="get" path="/combined_transfers/{uid}" example="queued" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.CombinedTransfers.GetAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetCombinedTransfersUidResponse](../../Models/Requests/GetCombinedTransfersUidResponse.md)**

### Errors

| Error Type                                                            | Status Code                                                           | Content Type                                                          |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| Newline53.Sdk.Models.Errors.GetCombinedTransfersUidForbiddenException | 403                                                                   | application/json                                                      |
| Newline53.Sdk.Models.Errors.GetCombinedTransfersUidNotFoundException  | 404                                                                   | application/json                                                      |
| Newline53.Sdk.Models.Errors.APIException                              | 4XX, 5XX                                                              | \*/\*                                                                 |