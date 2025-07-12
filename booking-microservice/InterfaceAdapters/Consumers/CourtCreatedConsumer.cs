
using Application.Interfaces;
using Contracts.Clubs;
using MassTransit;

namespace InterfaceAdapters.Consumers
{
    public class CourtCreatedConsumer : IConsumer<CourtCreatedMessage>
    {
        private readonly ICourtService _courtService;

        public CourtCreatedConsumer(ICourtService courtService)
        {
            _courtService = courtService;
        }

        public async Task Consume(ConsumeContext<CourtCreatedMessage> context)
        {
            await _courtService.AddCourtReferenceAsync(context.Message.Id, context.Message.ClubId, context.Message.BasePricePerHour);
        }
    }
}