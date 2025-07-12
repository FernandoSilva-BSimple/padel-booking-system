
using Application.Interfaces;
using Contracts.Bookings;
using Contracts.Clubs;
using MassTransit;

namespace InterfaceAdapters.Consumers
{
    public class BookingCreatedConsumer : IConsumer<BookingCreatedMessage>
    {
        private readonly IBookingService _BookingService;

        public BookingCreatedConsumer(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }

        public async Task Consume(ConsumeContext<BookingCreatedMessage> context)
        {
            await _BookingService.AddConsumedBookingAsync(context.Message.Id, context.Message.Price, context.Message.CourtId, context.Message.StartDate, context.Message.EndDate);
        }
    }
}