using Azure.Messaging.WebPubSub.Clients;

var client = new WebPubSubClient(new Uri("<client-access-uri>"));

client.GroupMessageReceived += eventArgs =>
{
    Console.WriteLine($"Receive group message from {eventArgs.Message.Group}: {eventArgs.Message.Data}");
    return Task.CompletedTask;
};

await client.StartAsync();

await client.SendToGroupAsync("testGroup", BinaryData.FromString("hello world"), WebPubSubDataType.Text);