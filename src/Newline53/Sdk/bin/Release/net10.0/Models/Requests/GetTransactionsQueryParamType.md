# GetTransactionsQueryParamType

Filter by type. Multiple values are allowed, e.g. `type[]=dispute&type[]=fee`.


## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = GetTransactionsQueryParamType.Ach;
```


## Values

| Name                  | Value                 |
| --------------------- | --------------------- |
| `Ach`                 | ach                   |
| `AchReturn`           | ach_return            |
| `AtmWithdrawal`       | atm_withdrawal        |
| `BookTransfer`        | book_transfer         |
| `CardLoad`            | card_load             |
| `CardPurchase`        | card_purchase         |
| `CardRefund`          | card_refund           |
| `CashLoad`            | cash_load             |
| `CorporateAction`     | corporate_action      |
| `Credit`              | credit                |
| `DeniedAuthorization` | denied_authorization  |
| `Dispute`             | dispute               |
| `Fee`                 | fee                   |
| `InstantPayment`      | instant_payment       |
| `Interest`            | interest              |
| `Other`               | other                 |
| `PeerToPeerTransfer`  | peer_to_peer_transfer |
| `Reversal`            | reversal              |
| `ReversedTransfer`    | reversed_transfer     |
| `Wire`                | wire                  |