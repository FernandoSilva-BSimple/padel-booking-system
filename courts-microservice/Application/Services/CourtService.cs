using Domain.IRepository;
using Domain.Interfaces;
using Domain.Factory;
using Domain.Models;
using Application.IPublishers;
using Application.DTO;
using AutoMapper;
namespace Application.Services;

public class CourtService : ICourtService
{
    private ICourtRepository _courtRepository;
    private ICourtFactory _courtFactory;
    private readonly IMessagePublisher _publisher;
    private readonly IMapper _mapper;

    public CourtService(ICourtRepository courtRepository, ICourtFactory courtFactory, IMessagePublisher messagePublisher, IMapper mapper)
    {
        _courtRepository = courtRepository;
        _courtFactory = courtFactory;
        _publisher = messagePublisher;
        _mapper = mapper;
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
        var existing = await _courtRepository.GetByIdAsync(id);
        if (existing is not null)
            return existing;

        var consumedCourt = await _courtFactory.Create(id, name, basePricePerHour, clubId);
        var court = await _courtRepository.AddAsync(consumedCourt);
        await _courtRepository.SaveChangesAsync();

        return court;
    }


    public async Task<ICourt> AddCourtAsync(ICourt court)
    {
        var courtAdded = await _courtRepository.AddAsync(court);
        await _courtRepository.SaveChangesAsync();

        return courtAdded;
    }

    public async Task<Result<IEnumerable<CourtDTO>>> GetAllAsync()
    {
        var courts = await _courtRepository.GetAllAsync();
        var courtsDto = _mapper.Map<IEnumerable<CourtDTO>>(courts);
        return Result<IEnumerable<CourtDTO>>.Success(courtsDto);
    }
}
