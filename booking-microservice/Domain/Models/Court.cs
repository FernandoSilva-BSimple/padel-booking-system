namespace Domain.Models;

public class Court : ICourt
{
    public Guid Id { get; set; }
    public Guid ClubId { get; set; }
    public decimal BasePricePerHour { get; set; }

    public Court(Guid id, Guid clubId, decimal basePricePerHour)
    {
        Id = id;
        ClubId = clubId;
        BasePricePerHour = basePricePerHour;
    }

    public Court() { }
}