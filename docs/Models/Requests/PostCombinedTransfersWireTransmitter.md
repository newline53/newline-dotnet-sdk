# PostCombinedTransfersWireTransmitter

Information about the Transmitter. Must be provided if the `initiator_type` is `transmitter`. Includes the transmitter's name, identifier, and address. The accepted address format depends on your program's wire address configuration. For `unstructured` format: `line1` and `country` are required. For `structured` format: `city` and `country` are required.



## Supported Types

### WireTransmitterTransferUnstructuredAddress

```csharp
PostCombinedTransfersWireTransmitter.CreateWireTransmitterTransferUnstructuredAddress(/* values here */);
```

### TransferStructuredAddress

```csharp
PostCombinedTransfersWireTransmitter.CreateTransferStructuredAddress(/* values here */);
```
