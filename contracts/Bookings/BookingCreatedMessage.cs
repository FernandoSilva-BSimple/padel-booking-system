namespace Contracts.Bookings;

public record BookingCreatedMessage(Guid Id, decimal Price, Guid CourtId, DateTime StartDate, DateTime EndDate);