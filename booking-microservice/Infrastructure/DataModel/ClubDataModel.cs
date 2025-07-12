using Domain.Models;
using Domain.Visitor;

namespace Infrastructure.DataModel;

public class ClubDataModel : IClubVisitor
{
    public Guid Id { get; set; }
    public TimePeriod TimePeriod { get; set; }

    public ClubDataModel(Guid id, TimePeriod timePeriod)
    {
        Id = id;
        TimePeriod = timePeriod;
    }

    public ClubDataModel() { }
}