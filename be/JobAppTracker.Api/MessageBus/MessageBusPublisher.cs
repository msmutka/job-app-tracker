using Azure.Messaging.ServiceBus;
using JobAppTracker.Api.Models;
using System.Text.Json;

public class AzureServiceBusPublisher : IMessageBusPublisher
{
    private readonly ServiceBusClient _client;
    private readonly ServiceBusSender _sender;

    public AzureServiceBusPublisher(IConfiguration configuration)
    {
        var connectionString = configuration["ServiceBus:ConnectionString"];
        var queueName = configuration["ServiceBus:QueueName"];

        _client = new ServiceBusClient(connectionString);
        _sender = _client.CreateSender(queueName);
    }

    public async Task PublishJobCreatedAsync(JobApplication job)
    {
        var message = new ServiceBusMessage(JsonSerializer.Serialize(job));
        await _sender.SendMessageAsync(message);
    }
}
