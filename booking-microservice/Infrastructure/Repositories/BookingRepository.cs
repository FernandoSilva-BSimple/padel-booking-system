using AutoMapper;
using Domain.IRepository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookingRepository : GenericRepositoryEF<IBooking, Booking, BookingDataModel>, IBookingRepository
{
    private readonly IMapper _mapper;
    public BookingRepository(PadelBookingContext context, IMapper mapper) : base(context, mapper)
    {
        _mapper = mapper;
    }
    public override IBooking? GetById(Guid id)
    {
        var bookingDM = _context.Set<BookingDataModel>().FirstOrDefault(c => c.Id == id);

        if (bookingDM == null)
            return null;

        var booking = _mapper.Map<BookingDataModel, Booking>(bookingDM);

        return booking;
    }

    public override async Task<IBooking?> GetByIdAsync(Guid id)
    {
        var bookingDM = await _context.Set<BookingDataModel>().FirstOrDefaultAsync(c => c.Id == id);

        if (bookingDM == null)
            return null;

        var booking = _mapper.Map<BookingDataModel, Booking>(bookingDM);

        return booking;
    }

    public Task<bool> HasAnActiveBooking(Guid courtId, DateTime initDate, DateTime finalDate)
    {
        return _context.Set<BookingDataModel>().AnyAsync(b =>
            b.CourtId == courtId &&
            b.BookingPeriod._initDate < finalDate &&
            initDate < b.BookingPeriod._finalDate
        );
    }
}