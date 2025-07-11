using Domain.Visitor;

namespace Infrastructure.DataModel;

public class CourtDataModel : ICourtVisitor
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal BasePricePerHour { get; set; }
    public Guid ClubId { get; set; }

    public CourtDataModel(Guid id, string name, decimal basePricePerHour, Guid clubId)
    {
        Id = id;
        Name = name;
        BasePricePerHour = basePricePerHour;
        ClubId = clubId;
    }

    public CourtDataModel() { }
}