using Amazon.SimpleNotificationService.Model;

namespace US.TechTalk.AWS.API.Messaging;

public interface ISnsMessenger
{
    Task<PublishResponse> PublishMessageAsync<T>(T message);
}
