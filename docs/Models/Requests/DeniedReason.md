# DeniedReason

The reason for the authorization denial. For wire transactions, must be one of (`vrn_archived`), (`vrn_locked`), (`international_payment`), (`unauthorized_credit`). For ACH transactions, must be one of (`vrn_archived`), (`vrn_locked`), (`debit_limit_exceeded`), (`unauthorized_credit`), (`unauthorized_debit`), (`insufficient_funds`)


## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = DeniedReason.DebitLimitExceeded;
```


## Values

| Name                   | Value                  |
| ---------------------- | ---------------------- |
| `DebitLimitExceeded`   | debit_limit_exceeded   |
| `InsufficientFunds`    | insufficient_funds     |
| `InternationalPayment` | international_payment  |
| `UnauthorizedCredit`   | unauthorized_credit    |
| `UnauthorizedDebit`    | unauthorized_debit     |
| `VrnArchived`          | vrn_archived           |
| `VrnLocked`            | vrn_locked             |