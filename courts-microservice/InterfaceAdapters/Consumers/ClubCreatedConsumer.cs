using Application.Interfaces;
using Contracts.Clubs;
using MassTransit;

namespace InterfaceAdapters.Consumers
{
    public class ClubCreatedConsumer : IConsumer<ClubCreatedMessage>
    {
        private readonly IClubService _clubService;

        public ClubCreatedConsumer(IClubService clubService)
        {
            _clubService = clubService;
        }

        public async Task Consume(ConsumeContext<ClubCreatedMessage> context)
        {
            var userId = context.Message.Id;
            await _clubService.AddClubReferenceAsync(userId);
        }
    }
}