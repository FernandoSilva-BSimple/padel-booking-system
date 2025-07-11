namespace Contracts.Clubs;

public record ClubCreatedMessage(Guid Id, string Name, TimeOnly StartTime, TimeOnly EndTime, Guid? CorrelationId);