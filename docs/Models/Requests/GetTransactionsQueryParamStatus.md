# GetTransactionsQueryParamStatus

Filter by status. Multiple values are allowed, e.g. `status[]=queued&status[]=pending`.


## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = GetTransactionsQueryParamStatus.Canceled;
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Canceled` | canceled   |
| `Queued`   | queued     |
| `Pending`  | pending    |
| `Settled`  | settled    |
| `Failed`   | failed     |
| `Expired`  | expired    |
| `Denied`   | denied     |