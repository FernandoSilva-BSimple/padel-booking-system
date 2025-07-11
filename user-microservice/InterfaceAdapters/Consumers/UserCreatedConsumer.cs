using Contracts.Users;
using MassTransit;

public class UserCreatedConsumer
{
    private readonly IUserService _userService;

    public UserCreatedConsumer(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Consume(ConsumeContext<UserCreatedMessage> context)
    {
        var msg = context.Message;
        await _userService.AddConsumed(msg.Id, msg.Name, msg.Email);

    }
}