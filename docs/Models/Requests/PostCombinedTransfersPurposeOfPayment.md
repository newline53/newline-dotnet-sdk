# PostCombinedTransfersPurposeOfPayment

An optional code supplied when an instant payment Transfer is initiated, indicating the kind of transaction being sent. If supplied, it must be one of the approved codes listed below, otherwise the Transfer is rejected. Omit the field or send an empty string to leave it unset; when unset it is returned as an empty string. Only applies to Newline initiated instant payments; it is not populated for received instant payments.


## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = PostCombinedTransfersPurposeOfPayment.Nows;
```


## Values

| Name   | Value  |
| ------ | ------ |
| `Nows` | NOWS   |
| `Gdds` | GDDS   |
| `Scve` | SCVE   |
| `Insc` | INSC   |
| `Insm` | INSM   |
| `Invs` | INVS   |
| `Payr` | PAYR   |
| `Ubil` | UBIL   |
| `Pdep` | PDEP   |
| `Acct` | ACCT   |
| `Cblk` | CBLK   |
| `Mp2P` | MP2P   |