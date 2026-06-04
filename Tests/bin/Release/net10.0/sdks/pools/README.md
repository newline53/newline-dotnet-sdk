# Pools

## Overview

Pools group multiple Customers for asset sharing and distributed account ownership. Each Pool is unique to a Customer or program.

**Endpoints:**

- GET [List Pools: GET /pools](https://developers.newline53.com/reference/get_pools)
    
- GET [Get a single Pool: GET /pools/{uid}](https://developers.newline53.com/reference/get_pools-uid)

A pool is a construct that Newline uses to associate multiple customers with each other. A Pool is always associated with at least one Customer, but all accounts are only ever associated with a single Pool. This enables asset sharing and distributed ownership of accounts across multiple Customers.

Newline currently supports single Customer Pools, where **one Customer is associated with one Pool and vice versa**. All accounts, transfers, and transactions are related to the Customer's Pool, not the Customer. The Pool UID appears on several endpoint responses and may be required by the API in some instances.

### Available Operations

* [List](#list) - List Pools
* [Get](#get) - Get a single Pool

## List

Retrieves a list of Pools filtered by the given parameters.


### Example Usage

<!-- UsageSnippet language="csharp" operationID="listPools" method="get" path="/pools" example="pool_list" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Pools.ListAsync(
    customerUid: "uKxmLxUEiSj5h4M3",
    limit: 100,
    offset: 0
);

// handle response
```

### Parameters

| Parameter                                                                                                                 | Type                                                                                                                      | Required                                                                                                                  | Description                                                                                                               | Example                                                                                                                   |
| ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- |
| `CustomerUid`                                                                                                             | *string*                                                                                                                  | :heavy_minus_sign:                                                                                                        | Filter by Customer. Multiple values are allowed, e.g. `customer_uid[]=uKxmLxUEiSj5h4M3&customer_uid[]=y9reyPMNEWuuYSC1`.<br/> | uKxmLxUEiSj5h4M3                                                                                                          |
| `Limit`                                                                                                                   | *long*                                                                                                                    | :heavy_minus_sign:                                                                                                        | Maximum number of items to retrieve. This filter is automatically applied with the default value if not given.<br/>       |                                                                                                                           |
| `Offset`                                                                                                                  | *long*                                                                                                                    | :heavy_minus_sign:                                                                                                        | Index of the items to start retrieving from                                                                               |                                                                                                                           |

### Response

**[ListPoolsResponse](../../Models/Requests/ListPoolsResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |

## Get

Retrieve overall status about a Pool as well as its total Asset Balances across all associated accounts.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getPool" method="get" path="/pools/{uid}" -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Pools.GetAsync(uid: "<id>");

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `Uid`                                                                 | *string*                                                              | :heavy_check_mark:                                                    | Newline-generated unique id resource specific to the current endpoint |

### Response

**[GetPoolResponse](../../Models/Requests/GetPoolResponse.md)**

### Errors

| Error Type                               | Status Code                              | Content Type                             |
| ---------------------------------------- | ---------------------------------------- | ---------------------------------------- |
| Newline53.Sdk.Models.Errors.APIException | 4XX, 5XX                                 | \*/\*                                    |