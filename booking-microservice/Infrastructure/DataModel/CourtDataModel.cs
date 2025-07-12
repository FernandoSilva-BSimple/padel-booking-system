using Domain.Visitor;

namespace Infrastructure.DataModel;

public class CourtDataModel : ICourtVisitor
{
    public Guid Id { get; set; }
    public Guid ClubId { get; set; }
    public decimal BasePricePerHour { get; set; }
}