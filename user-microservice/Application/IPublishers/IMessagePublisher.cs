public interface IMessagePublisher
{
    Task PublishCreatedUserMessageAsync(Guid id, string name, string email);

}