# ListSyntheticAccountTypesSyntheticAccountCategory

The name of the Synthetic Account Category for this type. Accounts can be in one of several categories that indicate their handling properties and defining characteristics such as 'general' or 'external'. As an example, 'external' accounts do not actually hold any assets and are instead used to represent an account at an external institution for use in initiating transfers.

## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = ListSyntheticAccountTypesSyntheticAccountCategory.General;
```


## Values

| Name                     | Value                    |
| ------------------------ | ------------------------ |
| `General`                | general                  |
| `AchExternal`            | ach_external             |
| `InstantPaymentExternal` | instant_payment_external |
| `WireExternal`           | wire_external            |