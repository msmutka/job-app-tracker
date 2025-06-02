using JobAppTracker.Api.Models;

public interface IMessageBusPublisher
{
    Task PublishJobCreatedAsync(JobApplication job);
}
