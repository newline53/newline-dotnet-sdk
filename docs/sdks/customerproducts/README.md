# CustomerProducts

## Overview

### Available Operations

* [List](#list) - List Customer Products
* [Onboard](#onboard) - Onboard Customer onto a Product
* [Get](#get) - Get a single Customer Product

## List

List Customers and the Products they have onboarded onto, filtered by the given parameters.


### Example Usage

<!-- UsageSnippet language="csharp" operationID="listCustomerProducts" method="get" path="/customer_products" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.CustomerProducts.ListAsync(
    programUid: "pQtTCSXz57fuefzp",
    productUid: "zbJbEa72eKMgbbBv",
    customerUid: "uKxmLxUEiSj5h4M3"
);

// handle response
```

### Parameters

| Parameter                                                                                                                 | Type                                                                                                                      | Required                                                                                                                  | Description                                                                                                               | Example                                                                                                                   |
| ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- |
| `ProgramUid`                                                                                                              | *string*                                                                                                                  | :heavy_minus_sign:                                                                                                        | Only return Customer Products belonging to the submitted Program                                                          | pQtTCSXz57fuefzp                                                                                                          |
| `ProductUid`                                                                                                              | *string*                                                                                                                  | :heavy_minus_sign:                                                                                                        | Only return Customer Products belonging to the submitted Product                                                          | zbJbEa72eKMgbbBv                                                                                                          |
| `CustomerUid`                                                                                                             | *string*                                                                                                                  | :heavy_minus_sign:                                                                                                        | Filter by Customer. Multiple values are allowed, e.g. `customer_uid[]=uKxmLxUEiSj5h4M3&customer_uid[]=y9reyPMNEWuuYSC1`.<br/> | uKxmLxUEiSj5h4M3                                                                                                          |

### Response

**[ListCustomerProductsResponse](../../Models/Requests/ListCustomerProductsResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## Onboard

Submit a request to onboard a Customer onto a new product. Ensure all required Customer details have been provided with [Adjust Customer Data](https://developers.newline53.com/reference/put_customers-uid) before making this request. An error will be returned if details are missing or invalid.

The request to onboard a Customer serves as explicit confirmation from you that the Customer is ready for account opening. This event initiates the KYC/AML verification process and account opening in your Program. This is a billable event and is isolated intentionally for you to confirm that the Customer record is complete. Customer Onboarding is the event that locks the customer PII and profile responses from further edits.

Customer Onboarding is designed to work as follows:

- The Customer provides complete PII as defined by the Customers endpoint
- The Customer provides complete Customer Profile information as defined by the Product endpoint
- You submit a request to Customer Products with the specified Product this Customer is onboarding onto
- Newline performs a validation on the PII provided and the Customer Profile data to confirm all are valid

If the Customer passes these validations and meets the duration requirements described below, the Customer record is submitted to the KYC process

### Example Usage

<!-- UsageSnippet language="csharp" operationID="onboardCustomerProduct" method="post" path="/customer_products" example="missing-details" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;
using Newline53.Sdk.Models.Requests;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

OnboardCustomerProductRequest req = new OnboardCustomerProductRequest() {
    CustomerUid = "S62MaHx6WwsqG9vQ",
    ProductUid = "pQtTCSXz57fuefzp",
};

var res = await sdk.CustomerProducts.OnboardAsync(req);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [OnboardCustomerProductRequest](../../Models/Requests/OnboardCustomerProductRequest.md) | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |

### Response

**[OnboardCustomerProductResponse](../../Models/Requests/OnboardCustomerProductResponse.md)**

### Errors

| Error Type                                                                     | Status Code                                                                    | Content Type                                                                   |
| ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------ |
| Newline53.Sdk.Models.Errors.OnboardCustomerProductUnprocessableEntityException | 422                                                                            | application/json                                                               |
| Newline53.Sdk.Models.Errors.APIException                                       | 4XX, 5XX                                                                       | \*/\*                                                                          |

## Get

Retrieves a single Customer Product resource along with its associated Customer and Product

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getCustomerProduct" method="get" path="/customer_products/{uid}" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.CustomerProducts.GetAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetCustomerProductResponse](../../Models/Requests/GetCustomerProductResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |