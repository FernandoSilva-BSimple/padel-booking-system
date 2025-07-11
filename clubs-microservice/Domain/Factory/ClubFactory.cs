using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory.ClubFactory;

public class ClubFactory : IClubFactory
{
    public ClubFactory() { }

    public Club Create(string name, TimePeriod timePeriod)
    {
        return new Club(name, timePeriod);
    }

    public Club Create(Guid id, string name, TimePeriod timePeriod)
    {
        return new Club(id, name, timePeriod);
    }

    public Club Create(IClubVisitor visitor)
    {
        return new Club(visitor.Id, visitor.Name, visitor.TimePeriod);
    }
}
