using Domain.Models;

namespace Domain.Interfaces;

public interface IClub
{
    public Guid Id { get; }
    public TimePeriod TimePeriod { get; }
}