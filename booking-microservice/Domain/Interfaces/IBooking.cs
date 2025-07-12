using Domain.Models;

public interface IBooking
{
    public Guid Id { get; }
    public decimal Price { get; }
    public Guid CourtId { get; }
    public PeriodDateTime BookingPeriod { get; }

}