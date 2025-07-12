using Domain.Models;

namespace Application.IPublishers;

public interface IMessagePublisher
{
    Task PublishCreatedBookingMessageAsync(Guid Id, decimal Price, Guid courtId, PeriodDateTime bookingPeriod);
}
