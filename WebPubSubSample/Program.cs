using Azure.Messaging.WebPubSub.Clients;
using System.Diagnostics;
using WebPubSubSample;

var client = new WebPubSubClient(new Uri("<client-access-token>"),
    new WebPubSubClientOptions { Protocol = new ProtobufProtocol()});

var data = BinaryData.FromBytes([1, 2, 3]);

client.GroupMessageReceived += eventArgs =>
{
    Debug.Assert(Enumerable.SequenceEqual(eventArgs.Message.Data.ToArray(), data.ToArray()));
    Console.WriteLine($"Receive group message from {eventArgs.Message.Group}");
    return Task.CompletedTask;
};

await client.StartAsync();

await client.JoinGroupAsync("testGroup");

await client.SendToGroupAsync("testGroup", data, WebPubSubDataType.Binary);

await Task.Delay(1000);