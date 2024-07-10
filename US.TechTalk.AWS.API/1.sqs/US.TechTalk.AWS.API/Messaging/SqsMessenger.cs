using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;

namespace US.TechTalk.AWS.API.Messaging;

public class SqsMessenger(IAmazonSQS sqs, IOptions<QueueSettings> queueSettings) : ISqsMessenger
{
    private readonly IAmazonSQS _sqs = sqs;
    private readonly IOptions<QueueSettings> _queueSettings = queueSettings;
    private string? _queueUrl;

    public async Task<SendMessageResponse> SendMessageAsync<T>(T message)
    {
        var queueUrl = await GetQueueUrlAsync();

        var sendMessageRequest = new SendMessageRequest
        {
            QueueUrl = queueUrl,
            MessageBody = JsonSerializer.Serialize(message),
            MessageAttributes = new Dictionary<string, MessageAttributeValue>
            {
                {
                    "MessageType", new MessageAttributeValue
                    {
                        DataType = "String",
                        StringValue = typeof(T).Name
                    }
                }
            }
        };

        return await _sqs.SendMessageAsync(sendMessageRequest);
    }

    private async Task<string> GetQueueUrlAsync()
    {
        if (_queueUrl is not null)
        {
            return _queueUrl;
        }
        
        var queueUrlResponse = await _sqs.GetQueueUrlAsync(_queueSettings.Value.Name);
        _queueUrl = queueUrlResponse.QueueUrl;

        return _queueUrl;
    }
}
