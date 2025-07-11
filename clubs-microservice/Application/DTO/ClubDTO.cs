using Domain.Models;

namespace Application.DTO;

public class ClubDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public TimePeriod TimePeriod { get; set; } = default!;
}