using Application.Interfaces;
using Contracts.Clubs;
using Domain.Models;
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
            var timePeriod = new TimePeriod(context.Message.StartTime, context.Message.EndTime);

            await _clubService.AddClubReferenceAsync(userId, timePeriod);
        }
    }
}