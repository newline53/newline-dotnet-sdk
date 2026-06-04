# GetCombinedTransfersQueryParamStatus

Filter by status. Multiple values are allowed, e.g. `status[]=queued&status[]=pending`.


## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = GetCombinedTransfersQueryParamStatus.Queued;
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Queued`    | queued      |
| `Pending`   | pending     |
| `Failed`    | failed      |
| `Completed` | completed   |