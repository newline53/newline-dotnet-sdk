# GetTransactionsPaymentType

Recurring (R), single entry (S), or standing authorization entry (ST). If no value is provided, the default value populated in the NACHA file is for a single entry.


## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = GetTransactionsPaymentType.R;
```


## Values

| Name  | Value |
| ----- | ----- |
| `R`   | R     |
| `S`   | S     |
| `St`  | ST    |