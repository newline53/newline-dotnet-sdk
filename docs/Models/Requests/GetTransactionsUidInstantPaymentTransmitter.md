# GetTransactionsUidInstantPaymentTransmitter

Name and address of the Transmitter.



## Fields

| Field                                                       | Type                                                        | Required                                                    | Description                                                 | Example                                                     |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `Name`                                                      | *string*                                                    | :heavy_check_mark:                                          | Name of the Transmitter.<br/>                               | Marthas Bank                                                |
| `StreetNumber`                                              | *string*                                                    | :heavy_check_mark:                                          | Building number for Transmitter address. Alphanumeric only. | 123abc                                                      |
| `Street1`                                                   | *string*                                                    | :heavy_check_mark:                                          | Street name for Transmitter address                         | Abc St.                                                     |
| `City`                                                      | *string*                                                    | :heavy_check_mark:                                          | Maximum 35 characters                                       | Chicago                                                     |
| `State`                                                     | *string*                                                    | :heavy_check_mark:                                          | 2 characters. Must be a valid US state abbreviation.        | IL                                                          |
| `PostalCode`                                                | *string*                                                    | :heavy_check_mark:                                          | 5-digit string. ZIP+4 is allowed.                           | 60301                                                       |
| `Country`                                                   | *string*                                                    | :heavy_check_mark:                                          | N/A                                                         | null                                                        |