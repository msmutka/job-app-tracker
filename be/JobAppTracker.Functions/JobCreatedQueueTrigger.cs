using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

public class JobCreatedQueueTrigger
{
    private readonly ILogger _logger;

    public JobCreatedQueueTrigger(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<JobCreatedQueueTrigger>();
    }

    [Function("JobCreatedQueueTrigger")]
    public void Run(
        [ServiceBusTrigger("job-application-created", Connection = "ServiceBusConnection")]
        string message)
    {
        _logger.LogInformation($"Received message from Service Bus: {message}");

        var job = JsonSerializer.Deserialize<JobApplication>(message);
        _logger.LogInformation($"Parsed job title: {job?.Title}");
    }

    public class JobApplication
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public DateTime AppliedDate { get; set; }
    }
}
