using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CourtRepository : GenericRepositoryEF<ICourt, Court, CourtDataModel>, ICourtRepository
{

    private readonly IMapper _mapper;
    public CourtRepository(PadelBookingContext context, IMapper mapper) : base(context, mapper)
    {

        _mapper = mapper;
    }
    public override ICourt? GetById(Guid id)
    {
        var courtDM = _context.Set<CourtDataModel>().FirstOrDefault(c => c.Id == id);

        if (courtDM == null)
            return null;

        var court = _mapper.Map<CourtDataModel, Court>(courtDM);

        return court;
    }

    public override async Task<ICourt?> GetByIdAsync(Guid id)
    {
        var courtDM = await _context.Set<CourtDataModel>().FirstOrDefaultAsync(c => c.Id == id);

        if (courtDM == null)
            return null;

        var court = _mapper.Map<CourtDataModel, Court>(courtDM);

        return court;
    }

}