using Contracts.Courts;
using Domain.Interfaces;

namespace Application.IPublishers;

public interface IMessagePublisher
{
    Task PublishCreatedCourtMessageAsync(ICourt court);
    Task SendCreateCourtSagaCommandAsync(CreateRequestedCourtCommand command);
}