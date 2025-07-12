using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

public interface IClubFactory
{
    Club Create(Guid id, TimePeriod timePeriod);
    Club Create(IClubVisitor visitor);

}