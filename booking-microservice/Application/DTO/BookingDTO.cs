using Domain.Models;

namespace Application.DTO;

public class BookingDTO
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public Guid CourtId { get; set; }
    public PeriodDateTime BookingPeriod { get; set; }


    public BookingDTO(Guid id, decimal price, Guid courtId, PeriodDateTime bookingPeriod)
    {
        Id = id;
        Price = price;
        CourtId = courtId;
        BookingPeriod = bookingPeriod;
    }
}