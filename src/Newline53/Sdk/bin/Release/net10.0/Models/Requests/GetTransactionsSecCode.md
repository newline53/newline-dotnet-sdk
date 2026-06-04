# GetTransactionsSecCode

Standard Entry Class (SEC) code. Newline supports the following SEC codes: CCD, CIE, PPD, TEL, WEB. For more details, refer to our ACH guide's [section](https://developers.newline53.com/docs/ach#standard-entry-class-sec-codes) on SEC code use.


## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = GetTransactionsSecCode.Ccd;
```


## Values

| Name  | Value |
| ----- | ----- |
| `Ccd` | CCD   |
| `Cie` | CIE   |
| `Ppd` | PPD   |
| `Tel` | TEL   |
| `Web` | WEB   |