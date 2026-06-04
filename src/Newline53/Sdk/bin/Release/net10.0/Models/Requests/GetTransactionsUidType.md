# GetTransactionsUidType

Transactions are categorized by Type.  See the Transaction Statuses and Transaction Types section below for a list and definition of each Transaction Type that Newline supports.


## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = GetTransactionsUidType.Ach;
```


## Values

| Name                   | Value                  |
| ---------------------- | ---------------------- |
| `Ach`                  | ach                    |
| `AchReturn`            | ach_return             |
| `AtmWithdrawal`        | atm_withdrawal         |
| `BookTransfer`         | book_transfer          |
| `CardLoad`             | card_load              |
| `CardPurchase`         | card_purchase          |
| `CardRefund`           | card_refund            |
| `CashLoad`             | cash_load              |
| `CorporateAction`      | corporate_action       |
| `Credit`               | credit                 |
| `DeniedAuthorization`  | denied_authorization   |
| `Dispute`              | dispute                |
| `Fee`                  | fee                    |
| `InitiatedAchReturn`   | initiated_ach_return   |
| `InitiatedAchReversal` | initiated_ach_reversal |
| `InitiatedWireReturn`  | initiated_wire_return  |
| `InstantPayment`       | instant_payment        |
| `Interest`             | interest               |
| `Other`                | other                  |
| `PeerToPeerTransfer`   | peer_to_peer_transfer  |
| `Reversal`             | reversal               |
| `ReversedTransfer`     | reversed_transfer      |
| `SetAccountBalance`    | set_account_balance    |
| `Wire`                 | wire                   |