using Domain.Models;

namespace Domain.Visitor;

public interface IClubVisitor
{
    Guid Id { get; }
    TimePeriod TimePeriod { get; }
}