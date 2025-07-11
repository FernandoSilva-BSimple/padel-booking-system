namespace Contracts.Courts;

public record CreateRequestedCourtCommand(Guid CollabTempId, string Name, decimal BasePricePerHour, string ClubName, TimeOnly StartTime, TimeOnly EndTime);