using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory;

public class ClubFactory : IClubFactory
{
    public Club Create(IClubVisitor visitor)
    {
        var club = new Club(visitor.Id, visitor.TimePeriod);
        return club;
    }

    public Club Create(Guid id, TimePeriod timePeriod)
    {
        var club = new Club(id, timePeriod);
        return club;
    }
}