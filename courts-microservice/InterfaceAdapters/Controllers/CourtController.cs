using Application.DTO;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/courts")]
[ApiController]
public class CollaboratorController : ControllerBase
{
    private readonly ICourtService _courtService;
    private readonly ICourtTempService _courtTempService;

    public CollaboratorController(ICourtService courtService, ICourtTempService courtTempService)
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
}