using Application.IPublishers;
using Contracts.Clubs;
using Domain.Models;
using MassTransit;

namespace InterfaceAdapters.Publishers;

public class MassTransitPublisher : IMessagePublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public MassTransitPublisher(IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpoint)
    {
        _publishEndpoint = publishEndpoint;

    }

    public async Task PublishCreatedClubMessageAsync(Guid id, string name, TimePeriod timePeriod, Guid? correlationId)
    {
        await _publishEndpoint.Publish(new ClubCreatedMessage(id, name, timePeriod.Start, timePeriod.End, correlationId));
    }

}
