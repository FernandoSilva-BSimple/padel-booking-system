using Application.DTO;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
namespace InterfaceAdapters.Controllers;

[Route("api/clubs")]
[ApiController]
public class ClubController : ControllerBase
{
    private readonly IClubService _ClubService;
    public ClubController(IClubService ClubService)
    {
        _ClubService = ClubService;
    }

    // Post: api/Clubs
    [HttpPost]
    public async Task<ActionResult<CreateClubDTO>> PostClubs(CreateClubDTO ClubDTO)
    {
        {
            var ClubDTOResult = await _ClubService.Add(ClubDTO);
            return Ok(ClubDTOResult);
        }
    }

    // Get: api/Clubs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClubDTO>>> GetClubs()
    {
        var clubs = await _ClubService.GetAllAsync();
        return clubs.ToActionResult();
    }
}
