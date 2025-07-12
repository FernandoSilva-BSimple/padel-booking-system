namespace Domain.Visitor;

public interface ICourtVisitor
{
    Guid Id { get; }
    Guid ClubId { get; }
    decimal BasePricePerHour { get; }
}

