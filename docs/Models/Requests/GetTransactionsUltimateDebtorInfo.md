# GetTransactionsUltimateDebtorInfo

Information about the ultimate debtor (the entity on whose behalf the payment is made). Only populated if your program has enabled RTP Ultimate Debtor support.


## Fields

| Field                                                | Type                                                 | Required                                             | Description                                          | Example                                              |
| ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- |
| `UltimateDebtorName`                                 | *string*                                             | :heavy_check_mark:                                   | Name of the ultimate debtor                          | John Smith                                           |
| `StreetNumber`                                       | *string*                                             | :heavy_minus_sign:                                   | Building number. Alphanumeric only.                  | 123abc                                               |
| `Street1`                                            | *string*                                             | :heavy_minus_sign:                                   | Street name                                          | Abc St.                                              |
| `Street2`                                            | *string*                                             | :heavy_minus_sign:                                   | Optional second line of street                       | Suite 4A                                             |
| `City`                                               | *string*                                             | :heavy_minus_sign:                                   | Maximum 35 characters                                | Chicago                                              |
| `State`                                              | *string*                                             | :heavy_minus_sign:                                   | 2 characters. Must be a valid US state abbreviation. | IL                                                   |
| `PostalCode`                                         | *string*                                             | :heavy_minus_sign:                                   | 5-digit string. ZIP+4 is allowed.                    | 60301                                                |
| `Country`                                            | *string*                                             | :heavy_minus_sign:                                   | N/A                                                  | null                                                 |