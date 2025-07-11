using Application.DTO;
using Microsoft.AspNetCore.Mvc;
namespace InterfaceAdapters.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> PostUsers(UserDTO userDTO)
    {
        {
            var userDTOResult = await _userService.Add(userDTO);
            return Ok(userDTOResult);
        }
    }
}
