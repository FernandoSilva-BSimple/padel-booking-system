using Application.DTO;
using Application.IPublishers;
using Contracts.Courts;
using Domain.Models;
using MassTransit;

namespace InterfaceAdapters.Consumers;

public class CourtWithoutClubCreatedConsumer : IConsumer<CreateClubFromCourtCommand>
{

    private readonly IClubService _clubService;
    private readonly IMessagePublisher _publisher;

    public CourtWithoutClubCreatedConsumer(IClubService clubService, IMessagePublisher publisher)
    {
        _clubService = clubService;
        _publisher = publisher;
    }

    public async Task Consume(ConsumeContext<CreateClubFromCourtCommand> context)
    {
        var msg = context.Message;

        TimePeriod timePeriod = new TimePeriod(msg.StartTime, msg.EndTime);

        var clubDTO = new CreateClubDTO
        {
            Name = msg.ClubName,
            TimePeriod = timePeriod
        };

        await _clubService.AddClubFromSagaAsync(clubDTO, msg.CollabTempId);
    }
}
