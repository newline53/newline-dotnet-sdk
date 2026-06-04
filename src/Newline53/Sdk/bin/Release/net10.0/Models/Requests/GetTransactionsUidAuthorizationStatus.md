# GetTransactionsUidAuthorizationStatus

A value indicating the current state of authorization for this transaction.


## Example Usage

```csharp
using Newline53.Sdk.Models.Requests;

var value = GetTransactionsUidAuthorizationStatus.AutoApproved;
```


## Values

| Name                            | Value                           |
| ------------------------------- | ------------------------------- |
| `AutoApproved`                  | auto_approved                   |
| `AutoDenied`                    | auto_denied                     |
| `ClientApprovalPending`         | client_approval_pending         |
| `ClientApproved`                | client_approved                 |
| `ClientDenied`                  | client_denied                   |
| `ClientUnansweredAutoApproved`  | client_unanswered_auto_approved |
| `ClientUnansweredAutoDenied`    | client_unanswered_auto_denied   |
| `Created`                       | created                         |