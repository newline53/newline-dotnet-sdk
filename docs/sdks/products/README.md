# Products

## Overview

Products represent financial services available in your program. Discover onboarding requirements, prerequisites, and detailed product configurations.

**Endpoints:**

- GET [List Products: GET /products](https://developers.newline53.com/reference/get_products)
    
- GET [Get a single Product: GET /products/{uid}](https://developers.newline53.com/reference/get_products-uid)

The Products endpoint represents the financial products available to your Customers. It exposes the accounts, compliance, and Customer Profile Requirements necessary for your Customer to access the Product. For some programs, a customer must onboard one product before another product is made available. Newline will work with clients to define the required Product onboarding sequence as part of your Program.

Use the Products endpoint to view the Products available to your Program and the prerequisite information or actions that must be taken for a Customer to access the Product.

For more information about Newline's products and their utilization, please refer to the [Products Programs](https://developers.newline53.com/docs/product-programs) guides.

### Available Operations

* [List](#list) - List Products
* [Get](#get) - Get a single Product

## List

Products filtered by the given parameters.


### Example Usage

<!-- UsageSnippet language="csharp" operationID="listProducts" method="get" path="/products" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Products.ListAsync(programUid: "pQtTCSXz57fuefzp");

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `ProgramUid`                                            | *string*                                                | :heavy_minus_sign:                                      | Only return Products belonging to the submitted Program | pQtTCSXz57fuefzp                                        |

### Response

**[ListProductsResponse](../../Models/Requests/ListProductsResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## Get

Retrieve overall status about a Product as well as its configuration, availability, and any associated metadata.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getProduct" method="get" path="/products/{uid}" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Products.GetAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetProductResponse](../../Models/Requests/GetProductResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |