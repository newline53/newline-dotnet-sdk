# CreateSyntheticAccountCounterpartyAddressUnion

Address of the business or individual who owns the external account. The accepted format depends on your program's wire address configuration (`unstructured`, `structured`, or `both`). Unstructured format uses `line1`/`line2`/`line3`/`country`. Structured format uses `building_number`/`street_name`/`city`/`postal_code`/`state`/`country` (with `city` and `country` required).



## Supported Types

### CreateSyntheticAccountCounterpartyAddressUnstructuredAddress

```csharp
CreateSyntheticAccountCounterpartyAddressUnion.CreateCreateSyntheticAccountCounterpartyAddressUnstructuredAddress(/* values here */);
```

### CreateSyntheticAccountStructuredAddress

```csharp
CreateSyntheticAccountCounterpartyAddressUnion.CreateCreateSyntheticAccountStructuredAddress(/* values here */);
```
