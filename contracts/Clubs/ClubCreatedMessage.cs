namespace Contracts.Clubs;

public record ClubCreatedMessage(Guid Id, string Name, TimeOnly startTime, TimeOnly endTime);