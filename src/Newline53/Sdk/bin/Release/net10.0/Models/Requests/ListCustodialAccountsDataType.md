# ListCustodialAccountsDataType

`dda` accounts are liability DDA accounts. Any asset movements in or out of the brick-and-mortar accounts will be journaled in the `dda` Custodial Accounts. Balances shown in the `dda` accounts are the balances the owner Customers have.

`dda_cash_external` accounts are asset accounts, representing external accounts. When ODFI transfers, initiated by a Synthetic Transfer from or to external Synthetic Accounts, are settled, the `dda_cash_external` Custodial Accounts will be credited or debited.

`dda_cash_received` accounts are asset cash accounts. When RDFI transfers, initiated outside of Newline from or to Custodial Accounts, are settled, the `dda_cash_received` Custodial Accounts will be credited or debited.


## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = ListCustodialAccountsDataType.Dda;
```


## Values

| Name              | Value             |
| ----------------- | ----------------- |
| `Dda`             | dda               |
| `DdaCashExternal` | dda_cash_external |
| `DdaCashReceived` | dda_cash_received |