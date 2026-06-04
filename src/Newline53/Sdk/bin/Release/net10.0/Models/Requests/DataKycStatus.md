# DataKycStatus

A value indicating the state of KYC/AML evaluation.


## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = DataKycStatus.ManualReview;
```


## Values

| Name                       | Value                      |
| -------------------------- | -------------------------- |
| `ManualReview`             | manual_review              |
| `Approved`                 | approved                   |
| `Denied`                   | denied                     |
| `PendingIdDocuments`       | pending_id_documents       |
| `PendingPoaDocuments`      | pending_poa_documents      |
| `PendingIdandpoaDocuments` | pending_idandpoa_documents |
| `DocumentsProvided`        | documents_provided         |
| `DocumentsRejected`        | documents_rejected         |
| `RetakeImages`             | retake_images              |
| `PreVerified`              | pre_verified               |