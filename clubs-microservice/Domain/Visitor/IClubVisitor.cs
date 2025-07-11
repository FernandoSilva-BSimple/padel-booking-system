using Domain.Models;

namespace Domain.Visitor;

public interface IClubVisitor
{
    Guid Id { get; }
    string Name { get; }
    TimePeriod TimePeriod { get; }
}
