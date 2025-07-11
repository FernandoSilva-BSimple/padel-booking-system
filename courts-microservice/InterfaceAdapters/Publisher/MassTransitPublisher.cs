using Application.IPublishers;
using Contracts.Clubs;
using Contracts.Courts;
using Domain.Interfaces;
using Domain.Models;
using MassTransit;

namespace WebApi.Publishers
{
    public class MassTransitPublisher : IMessagePublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public MassTransitPublisher(IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpointProvider)
        {
            _publishEndpoint = publishEndpoint;
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task PublishCreatedCourtMessageAsync(ICourt court)
        {
            var eventMessage = new CourtCreatedMessage(
                court.Id,
                court.Name,
                court.BasePricePerHour,
                court.ClubId
            );

            await _publishEndpoint.Publish(eventMessage);
        }


        public async Task SendCreateCourtSagaCommandAsync(CreateRequestedCourtCommand command)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:courts-saga"));
            await endpoint.Send(command);
        }
    }
}
