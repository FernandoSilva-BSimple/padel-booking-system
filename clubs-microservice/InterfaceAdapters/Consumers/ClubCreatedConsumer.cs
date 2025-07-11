using Contracts.Clubs;
using MassTransit;


public class ClubCreatedConsumer : IConsumer<ClubCreatedMessage>
{
    private readonly IClubService _ClubService;

    public ClubCreatedConsumer(IClubService ClubService)
    {
        _ClubService = ClubService;
    }
    public async Task Consume(ConsumeContext<ClubCreatedMessage> context)
    {
        var msg = context.Message;
        await _ClubService.AddConsumed(msg.Id, msg.Name, msg.startTime, msg.endTime);
    }
}
