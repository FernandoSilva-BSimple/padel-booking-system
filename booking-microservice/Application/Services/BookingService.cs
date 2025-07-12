using Application.DTO;
using Application.Interfaces;
using Application.IPublishers;
using AutoMapper;
using Domain.IRepository;
using Domain.Models;

namespace Application.Services;

public class BookingService : IBookingService
{
    private readonly IMapper _mapper;
    private readonly IClubRepository _clubRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly ICourtRepository _courtRepository;
    private readonly IBookingFactory _bookingFactory;
    private readonly IMessagePublisher _publisher;

    public BookingService(IMapper mapper, IClubRepository clubRepository, IBookingRepository bookingRepository, ICourtRepository courtRepository, IBookingFactory bookingFactory, IMessagePublisher publisher)
    {
        _mapper = mapper;
        _clubRepository = clubRepository;
        _bookingRepository = bookingRepository;
        _courtRepository = courtRepository;
        _bookingFactory = bookingFactory;
        _publisher = publisher;
    }

    public async Task<Result<BookingDTO>> AddBookingAsync(CreateBookingDTO createBookingDTO)
    {
        //criar booking (já com courtId validado)
        var booking = await _bookingFactory.Create(createBookingDTO.Price, createBookingDTO.CourtId, createBookingDTO.BookingPeriod);

        //validar se a reserva está dentro das horas do clube
        var court = await _courtRepository.GetByIdAsync(createBookingDTO.CourtId);
        var club = await _clubRepository.GetByIdAsync(court!.ClubId);

        if (!IsWithinClubOpeningHours(createBookingDTO.BookingPeriod, club!.TimePeriod))
            return Result<BookingDTO>.Failure(Error.BadRequest("Booking period is outside club opening hours"));

        //validar se o court está livre neste horário
        var isOccupied = await _bookingRepository.HasAnActiveBooking(createBookingDTO.CourtId, createBookingDTO.BookingPeriod._initDate, createBookingDTO.BookingPeriod._finalDate);

        if (isOccupied) return Result<BookingDTO>.Failure(Error.BadRequest("Court is already booked for the selected period"));

        var created = await _bookingRepository.AddAsync(booking);

        var createdDto = _mapper.Map<BookingDTO>(created);

        //publicar a mensagem no rabbitmq
        await _publisher.PublishCreatedBookingMessageAsync(created.Id, created.Price, created.CourtId, created.BookingPeriod);

        return Result<BookingDTO>.Success(createdDto);
    }

    public async Task<IBooking> AddConsumedBookingAsync(Guid id, decimal price, Guid courtId, DateTime initDate, DateTime finalDate)
    {
        var periodDate = new PeriodDateTime(initDate, finalDate);

        var consumedBooking = _bookingFactory.Create(id, price, courtId, periodDate);
        var booking = await _bookingRepository.AddAsync(consumedBooking);
        await _bookingRepository.SaveChangesAsync();

        return booking;

    }
    public async Task<Result<IEnumerable<BookingDTO>>> GetAllAsync()
    {
        var bookings = await _bookingRepository.GetAllAsync();
        var bookingsDto = _mapper.Map<IEnumerable<BookingDTO>>(bookings);
        return Result<IEnumerable<BookingDTO>>.Success(bookingsDto);
    }

    public bool IsWithinClubOpeningHours(PeriodDateTime period, TimePeriod clubHours)
    {
        var startTime = period._initDate.TimeOfDay;
        var endTime = period._finalDate.TimeOfDay;
        return startTime >= clubHours.Start.ToTimeSpan() && endTime <= clubHours.End.ToTimeSpan();
    }
}