using Application.DTO;
using Application.IPublishers;
using AutoMapper;
using Domain.Factory;
using Domain.IRepository;
using Domain.Models;
namespace Application.Services;


public class ClubService : IClubService
{
    private IClubRepository _ClubRepository;
    private IClubFactory _ClubFactory;
    private readonly IMessagePublisher _publisher;
    private readonly IMapper _mapper;

    public ClubService(IClubRepository ClubRepository, IClubFactory ClubFactory, IMapper mapper, IMessagePublisher publisher)
    {
        _ClubRepository = ClubRepository;
        _ClubFactory = ClubFactory;
        _mapper = mapper;
        _publisher = publisher;
    }

    public async Task<CreateClubDTO> Add(CreateClubDTO ClubDTO)
    {
        var Club = _ClubFactory.Create(ClubDTO.Name, ClubDTO.TimePeriod);
        await _ClubRepository.AddAsync(Club);
        await _ClubRepository.SaveChangesAsync();

        await _publisher.PublishCreatedClubMessageAsync(Club.Id, Club.Name, Club.TimePeriod);

        return _mapper.Map<Club, CreateClubDTO>(Club);
    }

    public async Task<IEnumerable<IClub>> GetAll()
    {
        var Club = await _ClubRepository.GetAllAsync();
        return Club;
    }

    public async Task<IClub?> GetById(Guid Id)
    {
        var Club = await _ClubRepository.GetByIdAsync(Id);
        return Club;
    }

    public async Task<bool> Exists(Guid Id)
    {
        return await _ClubRepository.Exists(Id);
    }

    public async Task AddConsumed(Guid id, string name, TimeOnly startDate, TimeOnly endDate)
    {
        if (await Exists(id)) return;

        TimePeriod timePeriod = new TimePeriod(startDate, endDate);

        var Club = _ClubFactory.Create(id, name, timePeriod);

        await _ClubRepository.AddAsync(Club);
        await _ClubRepository.SaveChangesAsync();
    }

}
