using Domain.Models;

namespace Domain.Models;

public class Booking : IBooking
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public Guid CourtId { get; set; }
    public PeriodDateTime BookingPeriod { get; set; }

    public Booking(Guid id, decimal price, Guid courtId, PeriodDateTime bookingPeriod)
    {
        Id = id;
        Price = price;
        CourtId = courtId;
        BookingPeriod = bookingPeriod;
    }

    public Booking(decimal price, Guid courtId, PeriodDateTime bookingPeriod)
    {
        if (ValidatePrice(price) == false) throw new ArgumentException("Price must be greater than 0");
        Id = Guid.NewGuid();
        Price = price;
        CourtId = courtId;
        BookingPeriod = bookingPeriod;
    }

    public Booking() { }

    public bool ValidatePrice(decimal price)
    {
        return price > 0;
    }
}