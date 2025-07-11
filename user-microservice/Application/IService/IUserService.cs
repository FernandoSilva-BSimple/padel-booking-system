using Application.DTO;

public interface IUserService
{
    Task<UserDTO> Add(UserDTO userDTO);
    Task<IEnumerable<IUser>> GetAll();
    Task<IUser?> GetById(Guid Id);
    Task<bool> Exists(Guid Id);
    Task AddConsumed(Guid id, string name, string email);

}