using Domain.Models;

namespace Domain.Visitor;

public interface ICourtTempVisitor
{
    Guid Id { get; }
    string Name { get; }
    decimal BasePricePerHour { get; }
    string ClubName { get; }
    TimePeriod TimePeriod { get; }
}