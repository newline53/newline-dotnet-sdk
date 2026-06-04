# ListSyntheticAccountsInstantPayment

Contains Instant Payment-specific information. Only populated if the Synthetic Account is in the `instant_payments_external` category.



## Fields

| Field                                                                  | Type                                                                   | Required                                                               | Description                                                            | Example                                                                |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| `CounterpartyName`                                                     | *string*                                                               | :heavy_minus_sign:                                                     | Name of the business or individual who owns the counterparty Account.<br/> | Marge's Roofing Inc                                                    |
| `Email`                                                                | *string*                                                               | :heavy_minus_sign:                                                     | Email address of the counterparty                                      | payments@veryexcellentbusiness.com                                     |
| `Phone`                                                                | *string*                                                               | :heavy_minus_sign:                                                     | Exactly 10 digits long (no hyphens, parentheses, or spaces)            | 5555551212                                                             |