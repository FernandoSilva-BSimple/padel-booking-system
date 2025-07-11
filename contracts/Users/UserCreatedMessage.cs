namespace Contracts.Users;

public record UserCreatedMessage(Guid Id, string Name, string Email);
