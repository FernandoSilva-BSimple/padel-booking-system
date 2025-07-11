namespace Domain.Models;

public class TimePeriod
{
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }

    public TimePeriod(TimeOnly start, TimeOnly end)
    {
        if (!ValidateTimePeriod(start, end)) throw new ArgumentException("Invalid time period");

        Start = start;
        End = end;
    }

    public TimePeriod() { }

    public bool ValidateTimePeriod(TimeOnly start, TimeOnly end)
    {
        return start < end;
    }
}