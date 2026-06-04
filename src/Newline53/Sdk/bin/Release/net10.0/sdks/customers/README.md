# Customers

## Overview

The Customers section provides details on managing end-user accounts. Learn how to create, update, and archive customer records and onboard them to financial products while meeting KYC/AML requirements.

**Endpoints:**

- GET [List Customers: GET /customers](https://developers.newline53.com/reference/get_customers)
    
- POST [Create a new Customer: POST /customers](https://developers.newline53.com/reference/post_customers)
    
- GET [Get a single Customer: GET /customers/{uid}](https://developers.newline53.com/reference/get_customers-uid)
    
- PUT [Adjust Customer Data: PUT /customers/{uid}](https://developers.newline53.com/reference/put_customers-uid)
    
- DELETE [Archive a Customer: DELETE /customers/{uid}](https://developers.newline53.com/reference/delete_customers-uid)
    
A Customer on the Newline Platform is the end user of your application. Customers are unique to each Program, and managing all accounts and identifying information is handled on a Program-by-Program basis.  
The ability to create new Customers is also a preset condition of your Program at Newline. Please see the below sections for more details.

## Newline preset-Customers

In cases where the Client also serves as the Customer (i.e., the Client is both the end-user and the managing entity over any financial products), Newline will create Customers upon Program onboarding. Clients will also be precluded from creating new Customers.

## Client-initiated Customers

**Customer Onboarding Process for Clients**  
When managing customer onboarding, follow the outlined steps and key considerations below.

### Steps for Onboarding Customers:

1. Initial Submission:

    1. Submit the external_uid and email using the Customers Endpoint.

2. Provide Personally Identifiable Information (PII):

    1. After the initial submission, supply the remaining PII for the customer.

    2. Ensure that all required PII fields are complete. Requests with complete or missing fields will be accepted.

3. Edit PII (Optional):

    1. PII can be updated until a valid request is sent to onboard the customer to a product using the Customer Product Endpoint.

4. Submit Profile Responses:

    1. Provide profile responses to meet the product's profile requirements.

    2. Profile Requirements can include data such as:

        1. Risk tolerance

        2. Income level

        3. Other product-specific information

5. Verify Profile Requirements:

    1. Use the Product Endpoint to access the Profile Requirements and ensure the customer satisfies all prerequisites for onboarding.

6. Initiate Onboarding Request:

    1. Submit a valid onboarding request for the customer using the Customer Products Endpoint.

## Additional Considerations:

KYC/AML Verification:

- To join a program, customers must pass Know Your Customer (KYC) and Anti-Money Laundering (AML) identity verification as required by Fifth Third Bank.

- KYC_status on the customer record will indicate the current state of the KYC/AML workflow.

Once a valid onboarding request is received, Newline initiates KYC/AML verification using the customer's PII.  
**Verification statuses include:**

- Approved

- Manual Review

- Documents Required

- Denied

Newline will work with clients to define these states.

## Program-Specific Records:

- A new customer record must be created for each program, even if an identical customer exists in another program.

- Customer records are not accessible outside of their associated program.

## Customer Management Functions:

The Customers Endpoint can also be used to perform management actions such as:

- Freezing or unfreezing a customer

- Archiving a customer

### Available Operations

* [List](#list) - Get a list of Customers
* [Create](#create) - Create a new Customer
* [Get](#get) - Get a single Customer
* [Update](#update) - Adjust Customer Data
* [Archive](#archive) - Archive a Customer

## List

Retrieves a list of Customers filtered by the given parameters. Filter parameters are not case sensitive, but will only return exact matches.

Multiple filter parameters can be provided at once, but a result will not be returned unless there are exact matches for all submitted parameters. As an example: submitting `first_name=Olive&last_name=Oyl` would match exactly "Olive Oyl" but NOT "Olive Boyl" or "Oliver Oyl".

The list endpoint will not include sensitive Customer data such as address or DOB. This can only be retrieved by viewing a specific Customer record. By default we do not display Customers in the `initiated` status, as Customers in this status have not completed onboarding. To cause Customers with this status to be included in the list you must provide the `include_initiated=true` parameter.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="listCustomers" method="get" path="/customers" example="customer_list" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

ListCustomersRequest req = new ListCustomersRequest() {
    Uid = "uKxmLxUEiSj5h4M3",
    IncludeInitiated = true,
    CustomerType = QueryParamCustomerType.Primary,
    FirstName = "Olive",
    LastName = "Oyl",
    Email = "olive.oyl@popeyes.com",
    Locked = false,
    ProgramUid = "pQtTCSXz57fuefzp",
    BusinessName = "Business inc",
    ExternalUid = "client-generated-id",
    PoolUid = "wTSMX1GubP21ev2h",
};

var res = await sdk.Customers.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [ListCustomersRequest](../../Models/Requests/ListCustomersRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[ListCustomersResponse](../../Models/Requests/ListCustomersResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## Create

This endpoint is used to initialize a new Customer. All request body data is optional unless otherwise specified. For customer types other than `primary`, `customer_type` must be specified.

The `customer_type` cannot be changed after the customer is created. Customer details accepted by [Adjust Customer Data](https://developers.newline53.com/reference/put_customers-uid) can be sent in this request if desired. See Adjust Customer Data for an example with all customer details provided.

### Example Usage: empty_customer

<!-- UsageSnippet language="csharp" operationID="createCustomer" method="post" path="/customers" example="empty_customer" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;
using System;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateCustomerRequest req = new CreateCustomerRequest() {
    ExternalUid = "partner-generated-id",
    Email = "olive.oyl@newline53.com",
    Details = new CreateCustomerDetailsRequest() {
        FirstName = "Olive",
        MiddleName = "Olivia",
        LastName = "Oyl",
        Suffix = "Jr.",
        Phone = "5555551212",
        BusinessName = "Oliver's Olive Emporium",
        Ssn = "111-22-3333",
        Dob = DateOnly.Parse("1919-12-08"),
        Address = new CreateCustomerAddressRequest() {
            Street1 = "123 Abc St.",
            Street2 = "Suite 4A",
            City = "Chicago",
            State = "IL",
            PostalCode = "60301",
        },
    },
};

var res = await sdk.Customers.CreateAsync(req);

// handle response
```
### Example Usage: primary

<!-- UsageSnippet language="csharp" operationID="createCustomer" method="post" path="/customers" example="primary" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateCustomerRequest req = new CreateCustomerRequest() {
    ExternalUid = "client-generated-42",
    Email = "tomas@example.com",
};

var res = await sdk.Customers.CreateAsync(req);

// handle response
```
### Example Usage: primary-empty

<!-- UsageSnippet language="csharp" operationID="createCustomer" method="post" path="/customers" example="primary-empty" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateCustomerRequest req = new CreateCustomerRequest() {};

var res = await sdk.Customers.CreateAsync(req);

// handle response
```
### Example Usage: secondary

<!-- UsageSnippet language="csharp" operationID="createCustomer" method="post" path="/customers" example="secondary" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

CreateCustomerRequest req = new CreateCustomerRequest() {
    CustomerType = CustomerTypeRequest.Secondary,
    PrimaryCustomerUid = "dc6PApa2nn9K3jwL",
    ExternalUid = "client-generated-42",
    Email = "tomas@example.com",
};

var res = await sdk.Customers.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `request`                                                               | [CreateCustomerRequest](../../Models/Requests/CreateCustomerRequest.md) | :heavy_check_mark:                                                      | The request object to use for the request.                              |

### Response

**[CreateCustomerResponse](../../Models/Requests/CreateCustomerResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## Get

Retrieve overall status about a Customer as well as their total Asset Balances across all accounts.


### Example Usage

<!-- UsageSnippet language="csharp" operationID="getCustomer" method="get" path="/customers/{uid}" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Customers.GetAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetCustomerResponse](../../Models/Requests/GetCustomerResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## Update

Submit or update a Customer's personally identifiable information (PII) after the Customer is created. Before a Customer has been onboarded to a product with [Customer Product](https://developers.newline53.com/reference/post_customer-products), this endpoint may be used to update or remove any details without validations. After the Customer has been onboarded to a product, all validations will be enforced.

This endpoint is used to supply the remaining personally identifiable information (PII) for each Customer after they are created. The PII for a Customer must be submitted in full. Newline will not accept your request if any field is incomplete or missing.

PII can be edited for a Customer up until a valid request is sent to the Customer Product endpoint. Once a Customer is in a status of Active, subsequent calls to this endpoint will result in additional KYC/AML evaluations. Each KYC/AML evaluation will result in a billable event for your Program. Please work with Newline on how you plan to implement PII modifications for your Customers.

Only first_name, middle_name, last_name, suffix, email, phone, and address will be editable after a Customer is in a status of Active. Once Customer data is adjusted, the pii_confirmed_at field on the Customer record will be updated.

Newline accepts Tax Identifier Number in the Social Security Number field of the API. Newline performs validation on the SSN field supplied with a Customer to prevent invalid SSN values. Newline will reject a Customer record with a SSN value that does not adhere to the following parameters:

- The 1st part, 3-digits, may not include 000, 666
- The 2nd part, 2-digits, may range from 01 to 99
- The 3rd part, 4-digits, may range from 0001 to 9999

We will accept SSN and TIN in the SSN field of the /customers endpoint.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="updateCustomer" method="put" path="/customers/{uid}" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;
using System;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Customers.UpdateAsync(
    uid: "<id>",
    body: new UpdateCustomerRequestBody() {
        ExternalUid = "partner-generated-id",
        Email = "olive.oyl@newline53.com",
        Details = new UpdateCustomerDetailsRequest() {
            FirstName = "Olive",
            MiddleName = "Olivia",
            LastName = "Oyl",
            Suffix = "Jr.",
            Phone = "5555551212",
            BusinessName = "Oliver's Olive Emporium",
            Ssn = "111-22-3333",
            Dob = DateOnly.Parse("1919-12-08"),
            Address = new UpdateCustomerAddressRequest() {
                Street1 = "123 Abc St.",
                Street2 = "Suite 4A",
                City = "Chicago",
                State = "IL",
                PostalCode = "60301",
            },
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `Uid`                                                                           | *string*                                                                        | :heavy_check_mark:                                                              | Newline-generated unique id resource specific to the current endpoint           |
| `Body`                                                                          | [UpdateCustomerRequestBody](../../Models/Requests/UpdateCustomerRequestBody.md) | :heavy_check_mark:                                                              | N/A                                                                             |

### Response

**[UpdateCustomerResponse](../../Models/Requests/UpdateCustomerResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## Archive

Archiving a Customer refunds any remaining balance, closes all of their active Synthetic and Custodial Accounts and closes their Debit Cards. This process can take up to 8 business days to complete as the Transfers take place.

When archiving a customer, you can prevent them from reapplying to your program by setting `can_apply_again` to false. If you do not set any value, `can_apply_again` defaults to true.

When a request to archive a Customer is first received, the customer status will update to `pending_archival` and their accounts will be locked. When the archival process is complete, their customer status will update to `archived`. For a customer to move to the `archived` status, they must carry a $0 balance and have no pending transactions.

If the Customer has a positive balance across any accounts and a connected external account, Newline will initiate an ACH transfer to zero out the account balance and move the customer to the `archived` status.

If the Customer does not have an external account or the ACH transfer fails, Newline will mail a paper check to the Customer address on file to zero out the account balance and move the customer to the `archived` status.

If the Customer has a negative balance across any accounts, the negative account balances must be brought up to or greater than $0.00 before the archival workflow can continue.

Once archived, a Customer's records will still be available for historical purposes (according to the bank’s record retention schedule), but they will not be able to open any new Accounts. The Customer can still apply again as long as `can_apply_again` is not set to false.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="deleteCustomer" method="delete" path="/customers/{uid}" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Customers.ArchiveAsync(
    uid: "<id>",
    body: new DeleteCustomerRequestBody() {
        ArchiveNote = "for inactivity",
        DestinationSyntheticAccountUid = "oBASVwLQB4RojU5X",
    }
);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `Uid`                                                                           | *string*                                                                        | :heavy_check_mark:                                                              | Newline-generated unique id resource specific to the current endpoint           |
| `Body`                                                                          | [DeleteCustomerRequestBody](../../Models/Requests/DeleteCustomerRequestBody.md) | :heavy_check_mark:                                                              | N/A                                                                             |

### Response

**[DeleteCustomerResponse](../../Models/Requests/DeleteCustomerResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |