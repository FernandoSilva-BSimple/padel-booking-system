using Domain.Visitor;

namespace Domain.Factory.UserFactory;

public class UserFactory : IUserFactory
{
    public UserFactory() { }

    public User Create(string name, string email)
    {
        return new User(name, email);
    }

    public User Create(Guid id, string name, string email)
    {
        return new User(id, name, email);
    }

    public User Create(IUserVisitor visitor)
    {
        return new User(visitor.Id, visitor.Name, visitor.Email);
    }
}
