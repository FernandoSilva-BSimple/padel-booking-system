using Domain.Visitor;

public interface IUserFactory
{
    User Create(string name, string email);
    User Create(Guid id, string name, string email);
    User Create(IUserVisitor visitor);

}