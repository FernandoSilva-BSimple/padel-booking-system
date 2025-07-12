using Application.IPublishers;
using Contracts.Bookings;
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

        public MassTransitPublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishCreatedBookingMessageAsync(Guid id, decimal price, Guid courtId, PeriodDateTime bookingPeriod)
        {
            var eventMessage = new BookingCreatedMessage(
                id,
                price,
                courtId,
                bookingPeriod._initDate,
                bookingPeriod._finalDate
            );

            await _publishEndpoint.Publish(eventMessage);
        }
    }
}
