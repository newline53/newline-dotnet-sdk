# GetTransactionEventsQueryParamType

Filter by type. Multiple values are allowed, e.g. `type[]=odfi_ach_deposit&type[]=odfi_ach_withdrawal`.


## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = GetTransactionEventsQueryParamType.OdfiAchDeposit;
```


## Values

| Name                | Value               |
| ------------------- | ------------------- |
| `OdfiAchDeposit`    | odfi_ach_deposit    |
| `OdfiAchWithdrawal` | odfi_ach_withdrawal |
| `RdfiAchDeposit`    | rdfi_ach_deposit    |
| `RdfiAchWithdrawal` | rdfi_ach_withdrawal |