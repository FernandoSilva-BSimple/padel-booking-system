using Contracts.Users;
using MassTransit;

namespace InterfaceAdapters.Publishers;

public class MassTransitPublisher : IMessagePublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public MassTransitPublisher(IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpoint)
    {
        _publishEndpoint = publishEndpoint;

    }

    public async Task PublishCreatedUserMessageAsync(Guid id, string name, string email)
    {
        await _publishEndpoint.Publish(new UserCreatedMessage(id, name, email));
    }

}
