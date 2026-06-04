# QueryParamCustomerType

Only return Customers with a customer type matching exactly what is submitted. Multiple values are allowed e.g. `customer_type[]=primary&customer_type[]=secondary`.


## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = QueryParamCustomerType.Primary;
```


## Values

| Name             | Value            |
| ---------------- | ---------------- |
| `Primary`        | primary          |
| `Secondary`      | secondary        |
| `SoleProprietor` | sole_proprietor  |