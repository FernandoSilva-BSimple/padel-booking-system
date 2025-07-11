using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory;

public class CourtTempFactory : ICourtTempFactory
{
    public CourtTemp Create(string name, decimal basePricePerHour, string clubName, TimePeriod timePeriod)
    {
        return new CourtTemp(name, basePricePerHour, clubName, timePeriod);
    }

    public CourtTemp Create(ICourtTempVisitor courtTempVisitor)
    {
        return new CourtTemp(courtTempVisitor.Id, courtTempVisitor.Name, courtTempVisitor.BasePricePerHour, courtTempVisitor.ClubName, courtTempVisitor.TimePeriod);
    }

    public CourtTemp Create(Guid id, string name, decimal basePricePerHour, string clubName, TimePeriod timePeriod)
    {
        return new CourtTemp(id, name, basePricePerHour, clubName, timePeriod);
    }
}