namespace Contracts.Courts;

public record CreateRequestedCourtCommand(string Name, decimal BasePricePerHour, string ClubName, TimeOnly StartTime, TimeOnly EndTime);