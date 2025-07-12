using Application.DTO;
using AutoMapper;
using Domain.Factory;
using Domain.IRepository;
namespace Application.Services;


public class UserService : IUserService
{
    private IUserRepository _userRepository;
    private IUserFactory _userFactory;
    private readonly IMessagePublisher _publisher;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IUserFactory userFactory, IMapper mapper, IMessagePublisher publisher)
    {
        _userRepository = userRepository;
        _userFactory = userFactory;
        _mapper = mapper;
        _publisher = publisher;
    }

    public async Task<UserDTO> Add(UserDTO userDTO)
    {
        var user = _userFactory.Create(userDTO.Name, userDTO.Email);
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        await _publisher.PublishCreatedUserMessageAsync(user.Id, user.Name, user.Email);

        return _mapper.Map<User, UserDTO>(user);
    }

    public async Task AddConsumed(Guid id, string name, string email)
    {
        if (await Exists(id)) return;

        var user = _userFactory.Create(id, name, email);

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();
    }
    public async Task<IEnumerable<IUser>> GetAll()
    {
        var User = await _userRepository.GetAllAsync();
        return User;
    }

    public async Task<IUser?> GetById(Guid Id)
    {
        var User = await _userRepository.GetByIdAsync(Id);
        return User;
    }

    public async Task<bool> Exists(Guid Id)
    {
        return await _userRepository.Exists(Id);
    }

    public async Task<Result<IEnumerable<UserDTO>>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        var usersDto = _mapper.Map<IEnumerable<UserDTO>>(users);
        return Result<IEnumerable<UserDTO>>.Success(usersDto);
    }

}
