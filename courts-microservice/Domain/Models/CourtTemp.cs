using Domain.Models;

public class CourtTemp : ICourtTemp
{
    public Guid Id { get; }
    public string Name { get; }
    public decimal BasePricePerHour { get; }
    public string ClubName { get; }
    public TimePeriod TimePeriod { get; private set; }

    public CourtTemp(string name, decimal basePricePerHour, string clubName, TimePeriod timePeriod)
    {
        Id = Guid.NewGuid();
        Name = name;
        BasePricePerHour = basePricePerHour;
        ClubName = clubName;
        TimePeriod = timePeriod;
    }

    public CourtTemp(Guid id, string name, decimal basePricePerHour, string clubName, TimePeriod timePeriod)
    {
        Id = id;
        Name = name;
        BasePricePerHour = basePricePerHour;
        ClubName = clubName;
        TimePeriod = timePeriod;
    }
}