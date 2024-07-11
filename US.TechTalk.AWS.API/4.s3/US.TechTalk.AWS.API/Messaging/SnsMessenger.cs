using System.Text.Json;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.Extensions.Options;

namespace US.TechTalk.AWS.API.Messaging;

public class SnsMessenger(IAmazonSimpleNotificationService sns, IOptions<TopicSettings> topicSettings) : ISnsMessenger
{
    private readonly IAmazonSimpleNotificationService _sns = sns;
    private readonly IOptions<TopicSettings> _topicSettings = topicSettings;
    private string? _topicArn;

    public async Task<PublishResponse> PublishMessageAsync<T>(T message)
    {
        var topicArn = await GetQueueUrlAsync();

        var sendMessageRequest = new PublishRequest
        {
            TopicArn = topicArn,
            Message = JsonSerializer.Serialize(message),
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

        return await _sns.PublishAsync(sendMessageRequest);
    }

    private async Task<string> GetQueueUrlAsync()
    {
        if (_topicArn is not null)
        {
            return _topicArn;
        }
        
        var queueUrlResponse = await _sns.FindTopicAsync(_topicSettings.Value.Name);
        _topicArn = queueUrlResponse.TopicArn;

        return _topicArn;
    }
}
