namespace Domain.Visitor;

public interface ICourtVisitor
{
    Guid Id { get; }
    string Name { get; }
    decimal BasePricePerHour { get; }
    Guid ClubId { get; }
}
