# SyntheticAccounts

## Overview

### Available Operations

* [ListTypes](#listtypes) - List Synthetic Account Types
* [GetAccountType](#getaccounttype) - Get a Single Synthetic Account Type
* [List](#list) - List Synthetic Accounts
* [Create](#create) - Create a New Synthetic Account
* [Get](#get) - Get a single Synthetic Account
* [Update](#update) - Update the Synthetic Account metadata
* [Archive](#archive) - Archive a Synthetic Account
* [ListClosingBalances](#listclosingbalances) - List Synthetic Account Closing Balances
* [GetClosingBalance](#getclosingbalance) - Get a single Synthetic Account Closing Balance

## ListTypes

Retrieve a list of Synthetic Account Types available for use in your Program. These types define the behavior and characteristics of Synthetic Accounts.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="listSyntheticAccountTypes" method="get" path="/synthetic_account_types" example="synthetic_account_types_list" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.SyntheticAccounts.ListTypesAsync(
    programUid: "EhrQZJNjCd79LLYq",
    limit: 100,
    offset: 0
);

// handle response
```

### Parameters

| Parameter                                                                                                       | Type                                                                                                            | Required                                                                                                        | Description                                                                                                     | Example                                                                                                         |
| --------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------- |
| `ProgramUid`                                                                                                    | *string*                                                                                                        | :heavy_minus_sign:                                                                                              | Only list Synthetic Account Types that are available to be used by the given Program                            | EhrQZJNjCd79LLYq                                                                                                |
| `Limit`                                                                                                         | *long*                                                                                                          | :heavy_minus_sign:                                                                                              | Maximum number of items to retrieve. This filter is automatically applied with the default value if not given.<br/> |                                                                                                                 |
| `Offset`                                                                                                        | *long*                                                                                                          | :heavy_minus_sign:                                                                                              | Index of the items to start retrieving from                                                                     |                                                                                                                 |

### Response

**[ListSyntheticAccountTypesResponse](../../Models/Requests/ListSyntheticAccountTypesResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## GetAccountType

Returns a single Synthetic Account Type resource along with supporting details.

Enables changes to the Synthetic Account fields, including the Master Synthetic Account. The Master Synthetic Account remains identifiable by the `master_account` flag stored with the Synthetic Account record.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getSyntheticAccountType" method="get" path="/synthetic_account_types/{uid}" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.SyntheticAccounts.GetAccountTypeAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetSyntheticAccountTypeResponse](../../Models/Requests/GetSyntheticAccountTypeResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## List

Retrieve a list of Synthetic Accounts associated with the specified Customer and Pool. This endpoint supports filtering by account type, category, status, and sorting by balance or name.


### Example Usage

<!-- UsageSnippet language="csharp" operationID="listSyntheticAccounts" method="get" path="/synthetic_accounts" example="synthetic_accounts_list" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

ListSyntheticAccountsRequest req = new ListSyntheticAccountsRequest() {
    CustomerUid = "uKxmLxUEiSj5h4M3",
    ExternalUid = "client-generated-id",
    PoolUid = "wTSMX1GubP21ev2h",
    SyntheticAccountTypeUid = "q4mdMxMtjXfdbrjn",
    Status = ListSyntheticAccountsQueryParamStatus.Active,
};

var res = await sdk.SyntheticAccounts.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                             | Type                                                                                  | Required                                                                              | Description                                                                           |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `request`                                                                             | [ListSyntheticAccountsRequest](../../Models/Requests/ListSyntheticAccountsRequest.md) | :heavy_check_mark:                                                                    | The request object to use for the request.                                            |

### Response

**[ListSyntheticAccountsResponse](../../Models/Requests/ListSyntheticAccountsResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## Create

Create a new Synthetic Account in the Pool with the provided specification.

External Synthetic Accounts are counterparty records that represent accounts at external financial institutions. They contain all the necessary information to execute a payment. For specifics about each payment rail's requirements, refer to our [Payment Rails](https://developers.newline53.com/docs/payment-rails) guides.

### Example Usage: ach_account

<!-- UsageSnippet language="csharp" operationID="createSyntheticAccount" method="post" path="/synthetic_accounts" example="ach_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateSyntheticAccountRequest req = new CreateSyntheticAccountRequest() {
    ExternalUid = "partner-generated-id",
    Name = "New Resource Name",
    PoolUid = "kaxHFJnWvJxRJZxq",
    SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
    RoutingNumber = "123456789",
    AccountNumber = "123456789012",
    ExternalProcessorToken = "processor-sandbox-96d86f35-ef58-4e4a-826f-4870b5d677f2",
    Ach = new CreateSyntheticAccountAchRequest() {
        AccountType = CreateSyntheticAccountAccountTypeRequest.Checking,
        CounterpartyName = "Thelma's Flooring LLC",
    },
    InstantPayment = new CreateSyntheticAccountInstantPaymentRequest() {
        CounterpartyAddress = new CreateSyntheticAccountInstantPaymentCounterpartyAddressRequest() {
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
    Wire = new CreateSyntheticAccountWireRequest() {
        CounterpartyAddress = CreateSyntheticAccountCounterpartyAddressUnion.CreateCreateSyntheticAccountCounterpartyAddressUnstructuredAddress(
            new CreateSyntheticAccountCounterpartyAddressUnstructuredAddress() {
                Line1 = "234 Xyz Rd",
                Line2 = "APT 5",
                Line3 = "Boston, MA 02110",
                Country = "US",
            }
        ),
        CounterpartyName = "Marge's Roofing Inc",
        CounterpartyBankAddress = new CreateSyntheticAccountCounterpartyBankAddressUnstructuredAddressRequest() {
            Line1 = "123 Abc St.",
            Line2 = "Boring, Oregon 97009",
            Line3 = null,
            Country = null,
        },
        CounterpartyBankName = "East West Regional Bank",
    },
};

var res = await sdk.SyntheticAccounts.CreateAsync(req);

// handle response
```
### Example Usage: general_synthetic_account

<!-- UsageSnippet language="csharp" operationID="createSyntheticAccount" method="post" path="/synthetic_accounts" example="general_synthetic_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateSyntheticAccountRequest req = new CreateSyntheticAccountRequest() {
    ExternalUid = "partner-generated-id",
    Name = "New Resource Name",
    PoolUid = "kaxHFJnWvJxRJZxq",
    SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
    RoutingNumber = "123456789",
    AccountNumber = "123456789012",
    ExternalProcessorToken = "processor-sandbox-96d86f35-ef58-4e4a-826f-4870b5d677f2",
    Ach = new CreateSyntheticAccountAchRequest() {
        AccountType = CreateSyntheticAccountAccountTypeRequest.Checking,
        CounterpartyName = "Thelma's Flooring LLC",
    },
    InstantPayment = new CreateSyntheticAccountInstantPaymentRequest() {
        CounterpartyAddress = new CreateSyntheticAccountInstantPaymentCounterpartyAddressRequest() {
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
    Wire = new CreateSyntheticAccountWireRequest() {
        CounterpartyAddress = CreateSyntheticAccountCounterpartyAddressUnion.CreateCreateSyntheticAccountCounterpartyAddressUnstructuredAddress(
            new CreateSyntheticAccountCounterpartyAddressUnstructuredAddress() {
                Line1 = "234 Xyz Rd",
                Line2 = "APT 5",
                Line3 = "Boston, MA 02110",
                Country = "US",
            }
        ),
        CounterpartyName = "Marge's Roofing Inc",
        CounterpartyBankAddress = new CreateSyntheticAccountCounterpartyBankAddressUnstructuredAddressRequest() {
            Line1 = "123 Abc St.",
            Line2 = "Boring, Oregon 97009",
            Line3 = null,
            Country = null,
        },
        CounterpartyBankName = "East West Regional Bank",
    },
};

var res = await sdk.SyntheticAccounts.CreateAsync(req);

// handle response
```
### Example Usage: instant_payment_synthetic_account

<!-- UsageSnippet language="csharp" operationID="createSyntheticAccount" method="post" path="/synthetic_accounts" example="instant_payment_synthetic_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateSyntheticAccountRequest req = new CreateSyntheticAccountRequest() {
    ExternalUid = "partner-generated-id",
    Name = "New Resource Name",
    PoolUid = "kaxHFJnWvJxRJZxq",
    SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
    RoutingNumber = "123456789",
    AccountNumber = "123456789012",
    ExternalProcessorToken = "processor-sandbox-96d86f35-ef58-4e4a-826f-4870b5d677f2",
    Ach = new CreateSyntheticAccountAchRequest() {
        AccountType = CreateSyntheticAccountAccountTypeRequest.Checking,
        CounterpartyName = "Thelma's Flooring LLC",
    },
    InstantPayment = new CreateSyntheticAccountInstantPaymentRequest() {
        CounterpartyAddress = new CreateSyntheticAccountInstantPaymentCounterpartyAddressRequest() {
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
    Wire = new CreateSyntheticAccountWireRequest() {
        CounterpartyAddress = CreateSyntheticAccountCounterpartyAddressUnion.CreateCreateSyntheticAccountCounterpartyAddressUnstructuredAddress(
            new CreateSyntheticAccountCounterpartyAddressUnstructuredAddress() {
                Line1 = "234 Xyz Rd",
                Line2 = "APT 5",
                Line3 = "Boston, MA 02110",
                Country = "US",
            }
        ),
        CounterpartyName = "Marge's Roofing Inc",
        CounterpartyBankAddress = new CreateSyntheticAccountCounterpartyBankAddressUnstructuredAddressRequest() {
            Line1 = "123 Abc St.",
            Line2 = "Boring, Oregon 97009",
            Line3 = null,
            Country = null,
        },
        CounterpartyBankName = "East West Regional Bank",
    },
};

var res = await sdk.SyntheticAccounts.CreateAsync(req);

// handle response
```
### Example Usage: new_synthetic_account

<!-- UsageSnippet language="csharp" operationID="createSyntheticAccount" method="post" path="/synthetic_accounts" example="new_synthetic_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateSyntheticAccountRequest req = new CreateSyntheticAccountRequest() {
    ExternalUid = "partner-generated-id",
    Name = "Spinach Fund",
    PoolUid = "wTSMX1GubP21ev2h",
    SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
};

var res = await sdk.SyntheticAccounts.CreateAsync(req);

// handle response
```
### Example Usage: post_error_response

<!-- UsageSnippet language="csharp" operationID="createSyntheticAccount" method="post" path="/synthetic_accounts" example="post_error_response" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateSyntheticAccountRequest req = new CreateSyntheticAccountRequest() {
    ExternalUid = "partner-generated-id",
    Name = "New Resource Name",
    PoolUid = "kaxHFJnWvJxRJZxq",
    SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
    RoutingNumber = "123456789",
    AccountNumber = "123456789012",
    ExternalProcessorToken = "processor-sandbox-96d86f35-ef58-4e4a-826f-4870b5d677f2",
    Ach = new CreateSyntheticAccountAchRequest() {
        AccountType = CreateSyntheticAccountAccountTypeRequest.Checking,
        CounterpartyName = "Thelma's Flooring LLC",
    },
    InstantPayment = new CreateSyntheticAccountInstantPaymentRequest() {
        CounterpartyAddress = new CreateSyntheticAccountInstantPaymentCounterpartyAddressRequest() {
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
    Wire = new CreateSyntheticAccountWireRequest() {
        CounterpartyAddress = CreateSyntheticAccountCounterpartyAddressUnion.CreateCreateSyntheticAccountCounterpartyAddressUnstructuredAddress(
            new CreateSyntheticAccountCounterpartyAddressUnstructuredAddress() {
                Line1 = "234 Xyz Rd",
                Line2 = "APT 5",
                Line3 = "Boston, MA 02110",
                Country = "US",
            }
        ),
        CounterpartyName = "Marge's Roofing Inc",
        CounterpartyBankAddress = new CreateSyntheticAccountCounterpartyBankAddressUnstructuredAddressRequest() {
            Line1 = "123 Abc St.",
            Line2 = "Boring, Oregon 97009",
            Line3 = null,
            Country = null,
        },
        CounterpartyBankName = "East West Regional Bank",
    },
};

var res = await sdk.SyntheticAccounts.CreateAsync(req);

// handle response
```
### Example Usage: wire_synthetic_account

<!-- UsageSnippet language="csharp" operationID="createSyntheticAccount" method="post" path="/synthetic_accounts" example="wire_synthetic_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateSyntheticAccountRequest req = new CreateSyntheticAccountRequest() {
    ExternalUid = "partner-generated-id",
    Name = "New Resource Name",
    PoolUid = "kaxHFJnWvJxRJZxq",
    SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
    RoutingNumber = "123456789",
    AccountNumber = "123456789012",
    ExternalProcessorToken = "processor-sandbox-96d86f35-ef58-4e4a-826f-4870b5d677f2",
    Ach = new CreateSyntheticAccountAchRequest() {
        AccountType = CreateSyntheticAccountAccountTypeRequest.Checking,
        CounterpartyName = "Thelma's Flooring LLC",
    },
    InstantPayment = new CreateSyntheticAccountInstantPaymentRequest() {
        CounterpartyAddress = new CreateSyntheticAccountInstantPaymentCounterpartyAddressRequest() {
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
    Wire = new CreateSyntheticAccountWireRequest() {
        CounterpartyAddress = CreateSyntheticAccountCounterpartyAddressUnion.CreateCreateSyntheticAccountCounterpartyAddressUnstructuredAddress(
            new CreateSyntheticAccountCounterpartyAddressUnstructuredAddress() {
                Line1 = "234 Xyz Rd",
                Line2 = "APT 5",
                Line3 = "Boston, MA 02110",
                Country = "US",
            }
        ),
        CounterpartyName = "Marge's Roofing Inc",
        CounterpartyBankAddress = new CreateSyntheticAccountCounterpartyBankAddressUnstructuredAddressRequest() {
            Line1 = "123 Abc St.",
            Line2 = "Boring, Oregon 97009",
            Line3 = null,
            Country = null,
        },
        CounterpartyBankName = "East West Regional Bank",
    },
};

var res = await sdk.SyntheticAccounts.CreateAsync(req);

// handle response
```
### Example Usage: wire_synthetic_account_structured

<!-- UsageSnippet language="csharp" operationID="createSyntheticAccount" method="post" path="/synthetic_accounts" example="wire_synthetic_account_structured" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateSyntheticAccountRequest req = new CreateSyntheticAccountRequest() {
    ExternalUid = "partner-generated-id",
    Name = "New Resource Name",
    PoolUid = "kaxHFJnWvJxRJZxq",
    SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
    RoutingNumber = "123456789",
    AccountNumber = "123456789012",
    ExternalProcessorToken = "processor-sandbox-96d86f35-ef58-4e4a-826f-4870b5d677f2",
    Ach = new CreateSyntheticAccountAchRequest() {
        AccountType = CreateSyntheticAccountAccountTypeRequest.Checking,
        CounterpartyName = "Thelma's Flooring LLC",
    },
    InstantPayment = new CreateSyntheticAccountInstantPaymentRequest() {
        CounterpartyAddress = new CreateSyntheticAccountInstantPaymentCounterpartyAddressRequest() {
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
    Wire = new CreateSyntheticAccountWireRequest() {
        CounterpartyAddress = CreateSyntheticAccountCounterpartyAddressUnion.CreateCreateSyntheticAccountCounterpartyAddressUnstructuredAddress(
            new CreateSyntheticAccountCounterpartyAddressUnstructuredAddress() {
                Line1 = "234 Xyz Rd",
                Line2 = "APT 5",
                Line3 = "Boston, MA 02110",
                Country = "US",
            }
        ),
        CounterpartyName = "Marge's Roofing Inc",
        CounterpartyBankAddress = new CreateSyntheticAccountCounterpartyBankAddressUnstructuredAddressRequest() {
            Line1 = "123 Abc St.",
            Line2 = "Boring, Oregon 97009",
            Line3 = null,
            Country = null,
        },
        CounterpartyBankName = "East West Regional Bank",
    },
};

var res = await sdk.SyntheticAccounts.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [CreateSyntheticAccountRequest](../../Models/Requests/CreateSyntheticAccountRequest.md) | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |

### Response

**[CreateSyntheticAccountResponse](../../Models/Requests/CreateSyntheticAccountResponse.md)**

### Errors

| Error Type                                    | Status Code                                   | Content Type                                  |
| --------------------------------------------- | --------------------------------------------- | --------------------------------------------- |
| Newline53.Sdk.Models.Errors.ConflictException | 409                                           | application/json                              |
| Newline53.Sdk.Models.Errors.APIException      | 4XX, 5XX                                      | \*/\*                                         |

## Get

Returns a single Synthetic Account resource along with supporting details and account balances.

Note: Newline will suppress the `account_number` value for Synthetic Accounts in the `ach_external`, `wire_external`, and `instant_payment_external` categories. The `account_number_last_four` value will be returned in the response to help identify these Synthetic Accounts.

### Example Usage: ach_account

<!-- UsageSnippet language="csharp" operationID="getSyntheticAccount" method="get" path="/synthetic_accounts/{uid}" example="ach_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.SyntheticAccounts.GetAsync(uid: "<id>");

// handle response
```
### Example Usage: general_synthetic_account

<!-- UsageSnippet language="csharp" operationID="getSyntheticAccount" method="get" path="/synthetic_accounts/{uid}" example="general_synthetic_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.SyntheticAccounts.GetAsync(uid: "<id>");

// handle response
```
### Example Usage: instant_payment_synthetic_account

<!-- UsageSnippet language="csharp" operationID="getSyntheticAccount" method="get" path="/synthetic_accounts/{uid}" example="instant_payment_synthetic_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.SyntheticAccounts.GetAsync(uid: "<id>");

// handle response
```
### Example Usage: wire_synthetic_account

<!-- UsageSnippet language="csharp" operationID="getSyntheticAccount" method="get" path="/synthetic_accounts/{uid}" example="wire_synthetic_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.SyntheticAccounts.GetAsync(uid: "<id>");

// handle response
```
### Example Usage: wire_synthetic_account_structured

<!-- UsageSnippet language="csharp" operationID="getSyntheticAccount" method="get" path="/synthetic_accounts/{uid}" example="wire_synthetic_account_structured" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.SyntheticAccounts.GetAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetSyntheticAccountResponse](../../Models/Requests/GetSyntheticAccountResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## Update

Enables changes to the Synthetic Account fields, including the Master Synthetic Account. The Master Synthetic Account remains identifiable by the `master_account` flag stored with the Synthetic Account record.

### Example Usage: ach_account

<!-- UsageSnippet language="csharp" operationID="updateSyntheticAccount" method="put" path="/synthetic_accounts/{uid}" example="ach_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.SyntheticAccounts.UpdateAsync(
    uid: "<id>",
    body: new UpdateSyntheticAccountRequestBody() {
        ExternalUid = "partner-generated-id",
        Name = "New Resource Name",
        PoolUid = "kaxHFJnWvJxRJZxq",
        SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
        RoutingNumber = "123456789",
        AccountNumber = "123456789012",
        Ach = new UpdateSyntheticAccountAchRequest() {
            AccountType = UpdateSyntheticAccountAccountTypeRequest.Checking,
            CounterpartyName = "Thelma's Flooring LLC",
        },
        InstantPayment = new UpdateSyntheticAccountInstantPaymentRequest() {
            CounterpartyAddress = new UpdateSyntheticAccountInstantPaymentCounterpartyAddressRequest() {
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
        Wire = new UpdateSyntheticAccountWireRequest() {
            CounterpartyAddress = UpdateSyntheticAccountCounterpartyAddressUnion.CreateUpdateSyntheticAccountCounterpartyAddressUnstructuredAddress(
                new UpdateSyntheticAccountCounterpartyAddressUnstructuredAddress() {
                    Line1 = "234 Xyz Rd",
                    Line2 = "APT 5",
                    Line3 = "Boston, MA 02110",
                    Country = "US",
                }
            ),
            CounterpartyName = "Marge's Roofing Inc",
            CounterpartyBankAddress = new UpdateSyntheticAccountCounterpartyBankAddressUnstructuredAddressRequest() {
                Line1 = "123 Abc St.",
                Line2 = "Boring, Oregon 97009",
                Line3 = null,
                Country = null,
            },
            CounterpartyBankName = "East West Regional Bank",
        },
    }
);

// handle response
```
### Example Usage: general_synthetic_account

<!-- UsageSnippet language="csharp" operationID="updateSyntheticAccount" method="put" path="/synthetic_accounts/{uid}" example="general_synthetic_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.SyntheticAccounts.UpdateAsync(
    uid: "<id>",
    body: new UpdateSyntheticAccountRequestBody() {
        ExternalUid = "partner-generated-id",
        Name = "New Resource Name",
        PoolUid = "kaxHFJnWvJxRJZxq",
        SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
        RoutingNumber = "123456789",
        AccountNumber = "123456789012",
        Ach = new UpdateSyntheticAccountAchRequest() {
            AccountType = UpdateSyntheticAccountAccountTypeRequest.Checking,
            CounterpartyName = "Thelma's Flooring LLC",
        },
        InstantPayment = new UpdateSyntheticAccountInstantPaymentRequest() {
            CounterpartyAddress = new UpdateSyntheticAccountInstantPaymentCounterpartyAddressRequest() {
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
        Wire = new UpdateSyntheticAccountWireRequest() {
            CounterpartyAddress = UpdateSyntheticAccountCounterpartyAddressUnion.CreateUpdateSyntheticAccountCounterpartyAddressUnstructuredAddress(
                new UpdateSyntheticAccountCounterpartyAddressUnstructuredAddress() {
                    Line1 = "234 Xyz Rd",
                    Line2 = "APT 5",
                    Line3 = "Boston, MA 02110",
                    Country = "US",
                }
            ),
            CounterpartyName = "Marge's Roofing Inc",
            CounterpartyBankAddress = new UpdateSyntheticAccountCounterpartyBankAddressUnstructuredAddressRequest() {
                Line1 = "123 Abc St.",
                Line2 = "Boring, Oregon 97009",
                Line3 = null,
                Country = null,
            },
            CounterpartyBankName = "East West Regional Bank",
        },
    }
);

// handle response
```
### Example Usage: instant_payment_synthetic_account

<!-- UsageSnippet language="csharp" operationID="updateSyntheticAccount" method="put" path="/synthetic_accounts/{uid}" example="instant_payment_synthetic_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.SyntheticAccounts.UpdateAsync(
    uid: "<id>",
    body: new UpdateSyntheticAccountRequestBody() {
        ExternalUid = "partner-generated-id",
        Name = "New Resource Name",
        PoolUid = "kaxHFJnWvJxRJZxq",
        SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
        RoutingNumber = "123456789",
        AccountNumber = "123456789012",
        Ach = new UpdateSyntheticAccountAchRequest() {
            AccountType = UpdateSyntheticAccountAccountTypeRequest.Checking,
            CounterpartyName = "Thelma's Flooring LLC",
        },
        InstantPayment = new UpdateSyntheticAccountInstantPaymentRequest() {
            CounterpartyAddress = new UpdateSyntheticAccountInstantPaymentCounterpartyAddressRequest() {
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
        Wire = new UpdateSyntheticAccountWireRequest() {
            CounterpartyAddress = UpdateSyntheticAccountCounterpartyAddressUnion.CreateUpdateSyntheticAccountCounterpartyAddressUnstructuredAddress(
                new UpdateSyntheticAccountCounterpartyAddressUnstructuredAddress() {
                    Line1 = "234 Xyz Rd",
                    Line2 = "APT 5",
                    Line3 = "Boston, MA 02110",
                    Country = "US",
                }
            ),
            CounterpartyName = "Marge's Roofing Inc",
            CounterpartyBankAddress = new UpdateSyntheticAccountCounterpartyBankAddressUnstructuredAddressRequest() {
                Line1 = "123 Abc St.",
                Line2 = "Boring, Oregon 97009",
                Line3 = null,
                Country = null,
            },
            CounterpartyBankName = "East West Regional Bank",
        },
    }
);

// handle response
```
### Example Usage: missing_param_error

<!-- UsageSnippet language="csharp" operationID="updateSyntheticAccount" method="put" path="/synthetic_accounts/{uid}" example="missing_param_error" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.SyntheticAccounts.UpdateAsync(
    uid: "<id>",
    body: new UpdateSyntheticAccountRequestBody() {
        ExternalUid = "partner-generated-id",
        Name = "New Resource Name",
        PoolUid = "kaxHFJnWvJxRJZxq",
        SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
        RoutingNumber = "123456789",
        AccountNumber = "123456789012",
        Ach = new UpdateSyntheticAccountAchRequest() {
            AccountType = UpdateSyntheticAccountAccountTypeRequest.Checking,
            CounterpartyName = "Thelma's Flooring LLC",
        },
        InstantPayment = new UpdateSyntheticAccountInstantPaymentRequest() {
            CounterpartyAddress = new UpdateSyntheticAccountInstantPaymentCounterpartyAddressRequest() {
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
        Wire = new UpdateSyntheticAccountWireRequest() {
            CounterpartyAddress = UpdateSyntheticAccountCounterpartyAddressUnion.CreateUpdateSyntheticAccountCounterpartyAddressUnstructuredAddress(
                new UpdateSyntheticAccountCounterpartyAddressUnstructuredAddress() {
                    Line1 = "234 Xyz Rd",
                    Line2 = "APT 5",
                    Line3 = "Boston, MA 02110",
                    Country = "US",
                }
            ),
            CounterpartyName = "Marge's Roofing Inc",
            CounterpartyBankAddress = new UpdateSyntheticAccountCounterpartyBankAddressUnstructuredAddressRequest() {
                Line1 = "123 Abc St.",
                Line2 = "Boring, Oregon 97009",
                Line3 = null,
                Country = null,
            },
            CounterpartyBankName = "East West Regional Bank",
        },
    }
);

// handle response
```
### Example Usage: wire_synthetic_account

<!-- UsageSnippet language="csharp" operationID="updateSyntheticAccount" method="put" path="/synthetic_accounts/{uid}" example="wire_synthetic_account" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.SyntheticAccounts.UpdateAsync(
    uid: "<id>",
    body: new UpdateSyntheticAccountRequestBody() {
        ExternalUid = "partner-generated-id",
        Name = "New Resource Name",
        PoolUid = "kaxHFJnWvJxRJZxq",
        SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
        RoutingNumber = "123456789",
        AccountNumber = "123456789012",
        Ach = new UpdateSyntheticAccountAchRequest() {
            AccountType = UpdateSyntheticAccountAccountTypeRequest.Checking,
            CounterpartyName = "Thelma's Flooring LLC",
        },
        InstantPayment = new UpdateSyntheticAccountInstantPaymentRequest() {
            CounterpartyAddress = new UpdateSyntheticAccountInstantPaymentCounterpartyAddressRequest() {
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
        Wire = new UpdateSyntheticAccountWireRequest() {
            CounterpartyAddress = UpdateSyntheticAccountCounterpartyAddressUnion.CreateUpdateSyntheticAccountCounterpartyAddressUnstructuredAddress(
                new UpdateSyntheticAccountCounterpartyAddressUnstructuredAddress() {
                    Line1 = "234 Xyz Rd",
                    Line2 = "APT 5",
                    Line3 = "Boston, MA 02110",
                    Country = "US",
                }
            ),
            CounterpartyName = "Marge's Roofing Inc",
            CounterpartyBankAddress = new UpdateSyntheticAccountCounterpartyBankAddressUnstructuredAddressRequest() {
                Line1 = "123 Abc St.",
                Line2 = "Boring, Oregon 97009",
                Line3 = null,
                Country = null,
            },
            CounterpartyBankName = "East West Regional Bank",
        },
    }
);

// handle response
```
### Example Usage: wire_synthetic_account_structured

<!-- UsageSnippet language="csharp" operationID="updateSyntheticAccount" method="put" path="/synthetic_accounts/{uid}" example="wire_synthetic_account_structured" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.SyntheticAccounts.UpdateAsync(
    uid: "<id>",
    body: new UpdateSyntheticAccountRequestBody() {
        ExternalUid = "partner-generated-id",
        Name = "New Resource Name",
        PoolUid = "kaxHFJnWvJxRJZxq",
        SyntheticAccountTypeUid = "fRMwt6H14ovFUz1s",
        RoutingNumber = "123456789",
        AccountNumber = "123456789012",
        Ach = new UpdateSyntheticAccountAchRequest() {
            AccountType = UpdateSyntheticAccountAccountTypeRequest.Checking,
            CounterpartyName = "Thelma's Flooring LLC",
        },
        InstantPayment = new UpdateSyntheticAccountInstantPaymentRequest() {
            CounterpartyAddress = new UpdateSyntheticAccountInstantPaymentCounterpartyAddressRequest() {
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
        Wire = new UpdateSyntheticAccountWireRequest() {
            CounterpartyAddress = UpdateSyntheticAccountCounterpartyAddressUnion.CreateUpdateSyntheticAccountCounterpartyAddressUnstructuredAddress(
                new UpdateSyntheticAccountCounterpartyAddressUnstructuredAddress() {
                    Line1 = "234 Xyz Rd",
                    Line2 = "APT 5",
                    Line3 = "Boston, MA 02110",
                    Country = "US",
                }
            ),
            CounterpartyName = "Marge's Roofing Inc",
            CounterpartyBankAddress = new UpdateSyntheticAccountCounterpartyBankAddressUnstructuredAddressRequest() {
                Line1 = "123 Abc St.",
                Line2 = "Boring, Oregon 97009",
                Line3 = null,
                Country = null,
            },
            CounterpartyBankName = "East West Regional Bank",
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                                       | Type                                                                                            | Required                                                                                        | Description                                                                                     |
| ----------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| `Uid`                                                                                           | *string*                                                                                        | :heavy_check_mark:                                                                              | Newline-generated unique id resource specific to the current endpoint                           |
| `Body`                                                                                          | [UpdateSyntheticAccountRequestBody](../../Models/Requests/UpdateSyntheticAccountRequestBody.md) | :heavy_check_mark:                                                                              | N/A                                                                                             |

### Response

**[UpdateSyntheticAccountResponse](../../Models/Requests/UpdateSyntheticAccountResponse.md)**

### Errors

| Error Type                                                            | Status Code                                                           | Content Type                                                          |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| Newline53.Sdk.Models.Errors.UpdateSyntheticAccountBadRequestException | 400                                                                   | application/json                                                      |
| Newline53.Sdk.Models.Errors.APIException                              | 4XX, 5XX                                                              | \*/\*                                                                 |

## Archive

In order to archive a Synthetic Account, the account must:

- not be a Master Synthetic Account i.e. `master_account` must be false.
- have zero balance.
- have no pending Transfers.

Master Synthetic Accounts are archived when the Program Customer is archived ([DELETE /customers/:uid](https://developers.newline53.com/reference/delete_customers-uid)).

### Example Usage

<!-- UsageSnippet language="csharp" operationID="deleteSyntheticAccount" method="delete" path="/synthetic_accounts/{uid}" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.SyntheticAccounts.ArchiveAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[DeleteSyntheticAccountResponse](../../Models/Requests/DeleteSyntheticAccountResponse.md)**

### Errors

| Error Type                                                                     | Status Code                                                                    | Content Type                                                                   |
| ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------ |
| Newline53.Sdk.Models.Errors.DeleteSyntheticAccountUnprocessableEntityException | 422                                                                            | application/json                                                               |
| Newline53.Sdk.Models.Errors.APIException                                       | 4XX, 5XX                                                                       | \*/\*                                                                          |

## ListClosingBalances

Retrieves a paginated list of Synthetic Account Closing balances, filtered by various parameters.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="listSyntheticAccountClosingBalances" method="get" path="/synthetic_account_closing_balances" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;
using System;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

ListSyntheticAccountClosingBalancesRequest req = new ListSyntheticAccountClosingBalancesRequest() {
    SyntheticAccountUid = "4XkJnsfHsuqrxmeX",
    SyntheticAccountExternalUid = "4XkJnsfHsuqrxmeX",
    NetUsdClosingBalanceAsOf = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    NetUsdClosingBalanceBefore = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
    NetUsdClosingBalanceAfter = System.DateTime.Parse("2020-01-01T00:00:00Z").ToUniversalTime(),
};

var res = await sdk.SyntheticAccounts.ListClosingBalancesAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                                         | Type                                                                                                              | Required                                                                                                          | Description                                                                                                       |
| ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| `request`                                                                                                         | [ListSyntheticAccountClosingBalancesRequest](../../Models/Requests/ListSyntheticAccountClosingBalancesRequest.md) | :heavy_check_mark:                                                                                                | The request object to use for the request.                                                                        |

### Response

**[ListSyntheticAccountClosingBalancesResponse](../../Models/Requests/ListSyntheticAccountClosingBalancesResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## GetClosingBalance

Get a single Synthetic Account Closing Balance

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getSyntheticAccountClosingBalance" method="get" path="/synthetic_account_closing_balances/{uid}" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.SyntheticAccounts.GetClosingBalanceAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetSyntheticAccountClosingBalanceResponse](../../Models/Requests/GetSyntheticAccountClosingBalanceResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |