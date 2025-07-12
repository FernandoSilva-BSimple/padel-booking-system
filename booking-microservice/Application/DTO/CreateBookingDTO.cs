using Domain.Models;

namespace Application.DTO;

public class CreateBookingDTO
{
    public decimal Price { get; set; }
    public Guid CourtId { get; set; }
    public PeriodDateTime BookingPeriod { get; set; }


    public CreateBookingDTO(decimal price, Guid courtId, PeriodDateTime bookingPeriod)
    {
        Price = price;
        CourtId = courtId;
        BookingPeriod = bookingPeriod;
    }
}