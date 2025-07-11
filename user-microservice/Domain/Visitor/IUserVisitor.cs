namespace Domain.Visitor;

public interface IUserVisitor
{
    Guid Id { get; }
    string Name { get; }
    string Email { get; }
}
