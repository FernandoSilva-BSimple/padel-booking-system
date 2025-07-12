using Domain.Models;

namespace Domain.Visitor;

public interface IBookingVisitor
{
    Guid Id { get; }
    decimal Price { get; }
    Guid CourtId { get; }
    PeriodDateTime BookingPeriod { get; }
}