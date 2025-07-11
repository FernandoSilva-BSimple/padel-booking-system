using Application.DTO;
using Application.IPublishers;
using Contracts.Courts;
using Domain.IRepository;
using Domain.Models;

namespace Application.Services;

public class CourtTempService : ICourtTempService
{
    private readonly ICourtTempRepository _courtTempRepository;
    private readonly ICourtTempFactory _courtTempFactory;
    private readonly IMessagePublisher _publisher;
    public CourtTempService(ICourtTempRepository courtTempRepository, ICourtTempFactory courtTempFactory, IMessagePublisher publisher)
    {
        _courtTempRepository = courtTempRepository;
        _courtTempFactory = courtTempFactory;
        _publisher = publisher;
    }

    public async Task CreateCourtTempAsync(CreateRequestedCourtCommand command)
    {
        TimePeriod timePeriod = new TimePeriod(command.StartTime, command.EndTime);

        var courtTemp = _courtTempFactory.Create(command.CollabTempId, command.Name, command.BasePricePerHour, command.ClubName, timePeriod);
        await _courtTempRepository.AddAsync(courtTemp);
        await _courtTempRepository.SaveChangesAsync();
    }

    public async Task StartSagaAsync(CreateCourtAndClubDTO dto)
    {
        Guid collabTempId = Guid.NewGuid();
        CreateRequestedCourtCommand message = new(collabTempId, dto.Name, dto.BasePricePerHour, dto.ClubName, dto.TimePeriod.Start, dto.TimePeriod.End);
        await _publisher.SendCreateCourtSagaCommandAsync(message);
    }

    public async Task DeleteCourtTempAsync(Guid id)
    {
        var existing = await _courtTempRepository.GetByIdAsync(id) ?? throw new InvalidOperationException("Court not found.");
        await _courtTempRepository.RemoveAsync(existing);
        await _courtTempRepository.SaveChangesAsync();
    }

    public async Task<ICourtTemp> GetByIdAsync(Guid id)
    {
        var courtTempDM = await _courtTempRepository.GetByIdAsync(id) ?? throw new InvalidOperationException("CourtTemp not found.");

        return courtTempDM;
    }
}