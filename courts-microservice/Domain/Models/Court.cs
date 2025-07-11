using Domain.Interfaces;

namespace Domain.Models;

public class Court : ICourt
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal BasePricePerHour { get; set; }
    public Guid ClubId { get; set; }

    public Court(Guid id, string name, decimal basePricePerHour, Guid clubId)
    {
        if (ValidatePricePerHour(basePricePerHour) == false) throw new ArgumentException("Price per hour must be greater than 0");
        Id = id;
        Name = name;
        BasePricePerHour = basePricePerHour;
        ClubId = clubId;
    }

    public Court(string name, decimal basePricePerHour, Guid clubId)
    {
        if (ValidatePricePerHour(basePricePerHour) == false) throw new ArgumentException("Price per hour must be greater than 0");

        Id = Guid.NewGuid();
        Name = name;
        BasePricePerHour = basePricePerHour;
        ClubId = clubId;
    }

    public Court() { }

    public bool ValidatePricePerHour(decimal pricePerHour)
    {
        return pricePerHour > 0;
    }
}