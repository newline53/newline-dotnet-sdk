# QueryParamKycStatus

Filter by KYC status. Multiple values are allowed e.g. `kyc_status[]=approved&kyc_status[]=under_review`.

## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = QueryParamKycStatus.Approved;
```


## Values

| Name                       | Value                      |
| -------------------------- | -------------------------- |
| `Approved`                 | approved                   |
| `Denied`                   | denied                     |
| `DocumentsProvided`        | documents_provided         |
| `DocumentsRejected`        | documents_rejected         |
| `ManualReview`             | manual_review              |
| `PendingIdDocuments`       | pending_id_documents       |
| `PendingPoaDocuments`      | pending_poa_documents      |
| `PendingIdandpoaDocuments` | pending_idandpoa_documents |
| `RetakeImages`             | retake_images              |
| `PreVerified`              | pre_verified               |