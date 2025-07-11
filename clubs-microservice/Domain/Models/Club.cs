namespace Domain.Models;

public class Club : IClub
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public TimePeriod TimePeriod { get; set; }

    public Club(Guid id, string name, TimePeriod timePeriod)
    {
        Id = id;
        Name = name;
        TimePeriod = timePeriod;
    }

    public Club(string name, TimePeriod timePeriod)
    {
        Id = Guid.NewGuid();
        Name = name;
        TimePeriod = timePeriod;
    }

    public Club() { }
}