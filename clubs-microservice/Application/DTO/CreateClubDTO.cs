using Domain.Models;

namespace Application.DTO;

public class CreateClubDTO
{
    public string Name { get; set; } = string.Empty;
    public TimePeriod TimePeriod { get; set; } = default!;
}