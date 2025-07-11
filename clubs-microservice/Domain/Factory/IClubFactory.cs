using Domain.Models;
using Domain.Visitor;

public interface IClubFactory
{
    Club Create(string name, TimePeriod timePeriod);
    Club Create(Guid id, string name, TimePeriod timePeriod);
    Club Create(IClubVisitor visitor);

}