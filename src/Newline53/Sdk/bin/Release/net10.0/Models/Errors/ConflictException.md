# ConflictException

A new Synthetic Account is NOT created if the external_uid given is present but not unique



## Fields

| Field                                                                                     | Type                                                                                      | Required                                                                                  | Description                                                                               |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `Errors`                                                                                  | List<[CreateSyntheticAccountError](../../Models/Requests/CreateSyntheticAccountError.md)> | :heavy_minus_sign:                                                                        | N/A                                                                                       |
| `Status`                                                                                  | *long*                                                                                    | :heavy_minus_sign:                                                                        | HTTP Status Code                                                                          |
| `HttpMeta`                                                                                | [HTTPMetadata](../../Models/Components/HTTPMetadata.md)                                   | :heavy_check_mark:                                                                        | N/A                                                                                       |