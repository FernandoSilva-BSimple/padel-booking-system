using Domain.Models;

public interface ICourtTemp
{
    public Guid Id { get; }
    public string Name { get; }
    public decimal BasePricePerHour { get; }
    public string ClubName { get; }
    public TimePeriod TimePeriod { get; }
}