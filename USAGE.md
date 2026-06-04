<!-- Start SDK Example Usage [usage] -->
```csharp
using Newline53.Sdk;
using Newline53.Sdk.Models.Components;

var sdk = new NewlineSDK(security: new Security() {
    ProgramUid = "<YOUR_PROGRAM_UID_HERE>",
    HmacKey = "<YOUR_HMAC_KEY_HERE>",
});

var res = await sdk.Auth.GenerateTokenAsync();

// handle response
```
<!-- End SDK Example Usage [usage] -->