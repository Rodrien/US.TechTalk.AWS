using Amazon.SQS.Model;

namespace US.TechTalk.AWS.API.Messaging;

public interface ISqsMessenger
{
    Task<SendMessageResponse> SendMessageAsync<T>(T message);
}
