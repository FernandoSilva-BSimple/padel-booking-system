using Domain.Models;

namespace Application.IPublishers;

public interface IMessagePublisher
{
    Task PublishCreatedClubMessageAsync(Guid id, string name, TimePeriod timePeriod, Guid? correlationId);
}
