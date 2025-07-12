using Domain.Models;
using Domain.Visitor;

namespace Infrastructure.DataModel;

public class CourtTempDataModel : ICourtTempVisitor
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal BasePricePerHour { get; set; }
    public string ClubName { get; set; } = string.Empty;
    public TimePeriod TimePeriod { get; set; }

    public CourtTempDataModel(Guid id, string name, decimal basePricePerHour, string clubName, TimePeriod timePeriod)
    {
        Id = id;
        Name = name;
        BasePricePerHour = basePricePerHour;
        ClubName = clubName;
        TimePeriod = timePeriod;
    }

    public CourtTempDataModel() { }
}