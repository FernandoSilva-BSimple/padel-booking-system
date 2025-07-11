namespace Application.DTO;

public class CourtDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal BasePricePerHour { get; set; }
    public Guid ClubId { get; set; }

    public CourtDTO(Guid id, string name, decimal basePricePerHour, Guid clubId)
    {
        Id = id;
        Name = name;
        BasePricePerHour = basePricePerHour;
        ClubId = clubId;
    }
}