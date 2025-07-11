using Domain.Models;

public interface IClub
{
    public Guid Id { get; }
    public string Name { get; }
    public TimePeriod TimePeriod { get; }
}