using Domain.Interfaces;

namespace Domain.Models;

public class Club : IClub
{
    public Guid Id { get; set; }
    public TimePeriod TimePeriod { get; set; }

    public Club(Guid id, TimePeriod timePeriod)
    {
        Id = id;
        TimePeriod = timePeriod;
    }
}