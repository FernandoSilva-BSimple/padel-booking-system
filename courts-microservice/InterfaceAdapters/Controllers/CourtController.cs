using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/courts")]
[ApiController]
public class CourtController : ControllerBase
{
    private readonly ICourtService _courtService;
    private readonly ICourtTempService _courtTempService;

    public CourtController(ICourtService courtService, ICourtTempService courtTempService)
    {
        _courtService = courtService;
        _courtTempService = courtTempService;
    }

    [HttpPost]
    public async Task<ActionResult<CourtDTO>> Create([FromBody] CreateCourtDTO courtDTO)
    {
        var createCourtDTO = new CreateCourtDTO(courtDTO.Name, courtDTO.BasePricePerHour, courtDTO.ClubId);

        var courtCreated = await _courtService.Create(createCourtDTO);

        return courtCreated.ToActionResult();
    }

    [HttpPost("with-club")]
    public async Task<IActionResult> CreateCourtWithClub(
    [FromBody] CreateCourtAndClubDTO dto)
    {

        await _courtTempService.StartSagaAsync(dto);
        return Accepted();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourtDTO>>> GetAllAsync() => (await _courtService.GetAllAsync()).ToActionResult();
}