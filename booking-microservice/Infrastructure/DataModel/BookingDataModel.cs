using Domain.Models;
using Domain.Visitor;

public class BookingDataModel : IBookingVisitor
{
    public Guid Id { get; set; }

    public decimal Price { get; set; }

    public Guid CourtId { get; set; }

    public PeriodDateTime BookingPeriod { get; set; }

    public BookingDataModel(Guid id, decimal price, Guid courtId, PeriodDateTime bookingPeriod)
    {
        Id = id;
        Price = price;
        CourtId = courtId;
        BookingPeriod = bookingPeriod;
    }

    public BookingDataModel() { }
}