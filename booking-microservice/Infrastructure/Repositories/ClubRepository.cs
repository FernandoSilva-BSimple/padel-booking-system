using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ClubRepository : GenericRepositoryEF<IClub, Club, ClubDataModel>, IClubRepository
{

    private readonly IMapper _mapper;
    public ClubRepository(PadelBookingContext context, IMapper mapper) : base(context, mapper)
    {
        _mapper = mapper;
    }

    public async Task<bool> Exists(Guid Id)
    {
        var exists = await _context.Set<ClubDataModel>().AnyAsync(c => c.Id == Id);
        return exists;
    }

    public override IClub? GetById(Guid id)
    {
        var clubDM = _context.Set<ClubDataModel>().FirstOrDefault(c => c.Id == id);

        if (clubDM == null)
            return null;

        var club = _mapper.Map<ClubDataModel, Club>(clubDM);

        return club;
    }

    public override async Task<IClub?> GetByIdAsync(Guid id)
    {
        var clubDM = await _context.Set<ClubDataModel>().FirstOrDefaultAsync(c => c.Id == id);

        if (clubDM == null)
            return null;

        var club = _mapper.Map<ClubDataModel, Club>(clubDM);

        return club;
    }

    public async Task<TimePeriod?> GetTimePeriodAsync(Guid id)
    {
        var clubDM = await _context.Set<ClubDataModel>().FirstOrDefaultAsync(c => c.Id == id);
        if (clubDM == null) return null;
        return clubDM?.TimePeriod;
    }
}