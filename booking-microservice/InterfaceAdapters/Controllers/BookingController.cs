using Application.DTO;
using Application.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/bookings")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _BookingService;

    public BookingController(IBookingService BookingService)
    {
        _BookingService = BookingService;
    }

    [HttpPost]
    public async Task<ActionResult<BookingDTO>> Create([FromBody] CreateBookingDTO BookingDTO)
    {
        var createBookingDTO = new CreateBookingDTO(BookingDTO.Price, BookingDTO.CourtId, BookingDTO.BookingPeriod);

        var bookingCreated = await _BookingService.AddBookingAsync(createBookingDTO);

        return bookingCreated.ToActionResult();
    }
}