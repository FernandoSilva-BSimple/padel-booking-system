using Domain.Visitor;

namespace Domain.IRepository;

public interface IUserRepository : IGenericRepositoryEF<IUser, User, IUserVisitor>
{
    Task<Guid?> GetByEmailAsync(string email);
    Task<bool> Exists(Guid ID);
    Task<IUser?> UpdateUser(IUser user_);

}