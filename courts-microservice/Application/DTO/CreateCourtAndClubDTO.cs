using Domain.Models;

namespace Application.DTO;

public class CreateCourtAndClubDTO
{
    public string Name { get; set; }
    public decimal BasePricePerHour { get; set; }
    public string ClubName { get; set; }
    public TimePeriod TimePeriod { get; set; }
}