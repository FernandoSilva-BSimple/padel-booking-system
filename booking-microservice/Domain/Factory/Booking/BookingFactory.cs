using System.Threading.Tasks;
using Domain.IRepository;
using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory;

public class BookingFactory : IBookingFactory
{
    private readonly ICourtRepository _courtRepository;

    public BookingFactory(ICourtRepository courtRepository)
    {
        _courtRepository = courtRepository;
    }

    public Booking Create(Guid id, decimal price, Guid courtId, PeriodDateTime bookingPeriod)
    {
        var booking = new Booking(id, price, courtId, bookingPeriod);
        return booking;
    }

    public async Task<Booking> Create(decimal price, Guid courtId, PeriodDateTime bookingPeriod)
    {
        var court = await _courtRepository.GetByIdAsync(courtId);
        if (court == null) throw new ArgumentException("CourtId does not exist.");

        var booking = new Booking(price, courtId, bookingPeriod);
        return booking;
    }


    public Booking Create(IBookingVisitor visitor)
    {
        var booking = new Booking(visitor.Id, visitor.Price, visitor.CourtId, visitor.BookingPeriod);
        return booking;
    }
}