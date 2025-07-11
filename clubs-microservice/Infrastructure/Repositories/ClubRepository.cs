using AutoMapper;
using Domain.IRepository;
using Domain.Models;
using Infrastructure;
using Infrastructure.DataModel;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class ClubRepository : GenericRepositoryEF<IClub, Club, ClubDataModel>, IClubRepository
{
    private readonly IMapper _mapper;

    public ClubRepository(PadelBookingContext context, IMapper mapper) : base(context, mapper)
    {
        _mapper = mapper;
    }

    public override IClub? GetById(Guid id)
    {
        var clubDM = _context.Set<ClubDataModel>().FirstOrDefault(c => c.Id == id);

        if (clubDM == null) return null;

        var club = _mapper.Map<ClubDataModel, Club>(clubDM);
        return club;

    }

    public override async Task<IClub?> GetByIdAsync(Guid id)
    {
        var clubDM = await _context.Set<ClubDataModel>().FirstOrDefaultAsync(c => c.Id == id);

        if (clubDM == null) return null;

        var club = _mapper.Map<ClubDataModel, Club>(clubDM);
        return club;
    }

    public async Task<bool> Exists(Guid ID)
    {
        var clubDM = await _context.Set<ClubDataModel>().FirstOrDefaultAsync(u => u.Id == ID);
        if (clubDM == null)
            return false;
        return true;
    }

}