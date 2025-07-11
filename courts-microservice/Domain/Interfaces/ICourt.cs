namespace Domain.Interfaces;

public interface ICourt
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal BasePricePerHour { get; set; }
    public Guid ClubId { get; set; }
    public bool ValidatePricePerHour(decimal pricePerHour);

}