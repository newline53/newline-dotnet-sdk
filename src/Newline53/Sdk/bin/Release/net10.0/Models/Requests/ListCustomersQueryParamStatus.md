# ListCustomersQueryParamStatus

Filter by onboarding status. Please note that the `initiated` enum value will not be respected unless the `include_initiated=true` parameter is also provided. Multiple values are allowed e.g. `status[]=queued&status[]=active`.


## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = ListCustomersQueryParamStatus.Initiated;
```


## Values

| Name               | Value              |
| ------------------ | ------------------ |
| `Initiated`        | initiated          |
| `Queued`           | queued             |
| `IdentityVerified` | identity_verified  |
| `Active`           | active             |
| `ManualReview`     | manual_review      |
| `Rejected`         | rejected           |
| `PendingArchival`  | pending_archival   |
| `Archived`         | archived           |
| `UnderReview`      | under_review       |