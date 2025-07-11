namespace Application.DTO;

public class CreateCourtDTO
{
    public string Name { get; set; }
    public decimal BasePricePerHour { get; set; }
    public Guid ClubId { get; set; }

    public CreateCourtDTO(string name, decimal basePricePerHour, Guid clubId)
    {
        Name = name;
        BasePricePerHour = basePricePerHour;
        ClubId = clubId;
    }
}