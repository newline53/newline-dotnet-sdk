# CreateCustomerAddressRequest


## Fields

| Field                                                | Type                                                 | Required                                             | Description                                          | Example                                              |
| ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- | ---------------------------------------------------- |
| `Street1`                                            | *string*                                             | :heavy_check_mark:                                   | Maximum 35 characters                                | 123 Abc St.                                          |
| `Street2`                                            | *string*                                             | :heavy_minus_sign:                                   | Maximum 35 characters                                | Suite 4A                                             |
| `City`                                               | *string*                                             | :heavy_check_mark:                                   | Maximum 35 characters                                | Chicago                                              |
| `State`                                              | *string*                                             | :heavy_check_mark:                                   | 2 characters. Must be a valid US state abbreviation. | IL                                                   |
| `PostalCode`                                         | *string*                                             | :heavy_check_mark:                                   | 5-digit string. ZIP+4 is allowed.                    | 60301                                                |