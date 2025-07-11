using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CourtTempRepository : GenericRepositoryEF<ICourtTemp, CourtTemp, CourtTempDataModel>, ICourtTempRepository
{

    private readonly IMapper _mapper;
    public CourtTempRepository(PadelBookingContext context, IMapper mapper) : base(context, mapper)
    {
        _mapper = mapper;
    }
    public override ICourtTemp? GetById(Guid id)
    {
        var courtTempDM = _context.Set<CourtTempDataModel>().FirstOrDefault(c => c.Id == id);

        if (courtTempDM == null)
            return null;

        var court = _mapper.Map<CourtTempDataModel, CourtTemp>(courtTempDM);

        return court;
    }

    public override async Task<ICourtTemp?> GetByIdAsync(Guid id)
    {
        var courtTempDM = await _context.Set<CourtTempDataModel>().FirstOrDefaultAsync(c => c.Id == id);

        if (courtTempDM == null)
            return null;

        var court = _mapper.Map<CourtTempDataModel, CourtTemp>(courtTempDM);

        return court;
    }

    public override async Task RemoveAsync(ICourtTemp entity)
    {
        var temp = await _context.Set<CourtTempDataModel>().FirstOrDefaultAsync(t => t.Id == entity.Id);

        if (temp != null)
        {
            _context.Remove(temp);
            await _context.SaveChangesAsync();
        }
    }
}