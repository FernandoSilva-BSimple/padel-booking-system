using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory;

public class CourtFactory : ICourtFactory
{
    public Court Create(Guid id, Guid clubId, decimal basePricePerHour)
    {
        var court = new Court(id, clubId, basePricePerHour);
        return court;
    }

    public Court Create(ICourtVisitor visitor)
    {
        var court = new Court(visitor.Id, visitor.ClubId, visitor.BasePricePerHour);
        return court;
    }
}