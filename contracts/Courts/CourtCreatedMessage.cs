namespace Contracts.Clubs;

public record CourtCreatedMessage(Guid Id, string Name, decimal BasePricePerHour, Guid ClubId);