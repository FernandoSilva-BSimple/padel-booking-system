using Domain.Models;
using Domain.Visitor;

public interface ICourtTempFactory
{
    CourtTemp Create(string name, decimal basePricePerHour, string clubName, TimePeriod timePeriod);
    CourtTemp Create(ICourtTempVisitor visitor);
    CourtTemp Create(Guid id, string name, decimal basePricePerHour, string clubName, TimePeriod timePeriod);

}