# Web PubSub Client SDK with Protobuf protocol sample

## Run the sample

In Web PubSub Azure Portal, and In **key** blade copy the client access token with joining group permission and sending to group permission.
And put the token in

```dotnet
var client = new WebPubSubClient(new Uri("<token>"), new WebPubSubClientOptions { Protocol = new ProtobufProtocol()});
```

## Structure

The `Protos/webpubusb.client.proto` is the proto file provided by the service.
And `ProtobufProtocol.cs` is the the implementation of `WebPubSubProtocol` and it serialize and deserialize the `WebPubSubMessage` to and from wire protocol. If you need
to use protobuf protocol, you can copy and paste this file.
