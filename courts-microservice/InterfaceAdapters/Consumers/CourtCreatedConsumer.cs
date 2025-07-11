
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
            await _courtService.AddConsumedCourtAsync(context.Message.Id, context.Message.Name, context.Message.BasePricePerHour, context.Message.ClubId);
        }
    }
}