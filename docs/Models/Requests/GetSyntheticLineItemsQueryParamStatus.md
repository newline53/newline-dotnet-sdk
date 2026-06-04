# GetSyntheticLineItemsQueryParamStatus

Filter by status. Multiple values are allowed, e.g. `status[]=begun&status[]=in_progress`.


## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = GetSyntheticLineItemsQueryParamStatus.Begun;
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Begun`      | begun        |
| `Failed`     | failed       |
| `InProgress` | in_progress  |
| `Settled`    | settled      |