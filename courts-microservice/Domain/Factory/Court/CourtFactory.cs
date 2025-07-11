using System.Diagnostics.Metrics;
using Domain.IRepository;
using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory;

public class CourtFactory : ICourtFactory
{
    private readonly ICourtRepository _courtRepository;
    private readonly IClubRepository _clubRepository;

    public CourtFactory(ICourtRepository courtRepository, IClubRepository clubRepository)
    {
        _courtRepository = courtRepository;
        _clubRepository = clubRepository;
    }

    public Court ConvertFromTemp(ICourtTemp courtTemp, Guid clubId)
    {
        return new Court(courtTemp.Name, courtTemp.BasePricePerHour, clubId);
    }

    public async Task<Court> Create(string name, decimal basePricePerHour, Guid clubId)
    {
        var clubExists = await _clubRepository.Exists(clubId);
        if (!clubExists) throw new ArgumentException("Club does not exist.");

        return new Court(name, basePricePerHour, clubId);

    }

    public Court Create(ICourtVisitor visitor)
    {
        return new Court(visitor.Id, visitor.Name, visitor.BasePricePerHour, visitor.ClubId);
    }

    public async Task<Court> Create(Guid id, string name, decimal basePricePerHour, Guid clubId)
    {
        var clubExists = await _clubRepository.Exists(clubId);
        if (!clubExists) throw new ArgumentException("Club does not exist.");

        return new Court(id, name, basePricePerHour, clubId);
    }
}