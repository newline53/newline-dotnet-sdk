# GetCustodialLineItemsQueryParamStatus

Filter by status. Multiple values are allowed, e.g. `status[]=pending&status[]=settled`.


## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = GetCustodialLineItemsQueryParamStatus.Settled;
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Settled` | settled   |
| `Voided`  | voided    |