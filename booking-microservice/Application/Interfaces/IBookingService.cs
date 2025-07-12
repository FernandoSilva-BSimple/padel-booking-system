using Application.DTO;
using Domain.Models;

namespace Application.Interfaces;

public interface IBookingService
{
    Task<Result<BookingDTO>> AddBookingAsync(CreateBookingDTO createBookingDTO);
    bool IsWithinClubOpeningHours(PeriodDateTime period, TimePeriod clubHours);
    Task<IBooking> AddConsumedBookingAsync(Guid id, decimal price, Guid courtId, DateTime initDate, DateTime finalDate);
    Task<Result<IEnumerable<BookingDTO>>> GetAllAsync();
}