using Domain.Visitor;

namespace Infrastructure.DataModel;

public class ClubDataModel : IClubVisitor
{
    public Guid Id { get; set; }

    public ClubDataModel(Guid id)
    {
        Id = id;
    }

    public ClubDataModel() { }
}