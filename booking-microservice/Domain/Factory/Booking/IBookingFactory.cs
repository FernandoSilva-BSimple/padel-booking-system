using Domain.Models;
using Domain.Visitor;

public interface IBookingFactory
{
    Booking Create(Guid id, decimal price, Guid courtId, PeriodDateTime bookingPeriod);
    Task<Booking> Create(decimal price, Guid courtId, PeriodDateTime bookingPeriod);
    Booking Create(IBookingVisitor visitor);

}