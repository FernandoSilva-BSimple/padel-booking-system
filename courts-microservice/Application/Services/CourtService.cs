using Domain.IRepository;
using Domain.Interfaces;
using Domain.Factory;
using Domain.Models;
using Application.IPublishers;
using Application.DTO;
namespace Application.Services;

public class CourtService : ICourtService
{
    private ICourtRepository _courtRepository;
    private ICourtFactory _courtFactory;
    private readonly IMessagePublisher _publisher;

    public CourtService(ICourtRepository courtRepository, ICourtFactory courtFactory, IMessagePublisher messagePublisher)
    {
        _courtRepository = courtRepository;
        _courtFactory = courtFactory;
        _publisher = messagePublisher;
    }


    public async Task<Result<CourtDTO>> Create(CreateCourtDTO courtDTO)
    {
        ICourt newCourt;
        try
        {
            newCourt = await _courtFactory.Create(courtDTO.Name, courtDTO.BasePricePerHour, courtDTO.ClubId);
            newCourt = await _courtRepository.AddAsync(newCourt);

            var result = new CourtDTO(newCourt.Id, newCourt.Name, newCourt.BasePricePerHour, newCourt.ClubId);

            await _publisher.PublishCreatedCourtMessageAsync(newCourt);
            return Result<CourtDTO>.Success(result);
        }
        catch (ArgumentException ex)
        {
            return Result<CourtDTO>.Failure(Error.InternalServerError(ex.Message));
        }
    }


    public async Task<ICourt> AddConsumedCourtAsync(Guid id, string name, decimal basePricePerHour, Guid clubId)
    {
        var consumedCourt = await _courtFactory.Create(id, name, basePricePerHour, clubId);
        var court = await _courtRepository.AddAsync(consumedCourt);
        await _courtRepository.SaveChangesAsync();

        return court;

    }
}
