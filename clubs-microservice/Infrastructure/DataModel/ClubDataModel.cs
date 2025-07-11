using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models;
using Domain.Visitor;

namespace Infrastructure.DataModel
{
    [Table("Club")]
    public class ClubDataModel : IClubVisitor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TimePeriod TimePeriod { get; set; }

        public ClubDataModel(IClub club)
        {
            if (club.Id != Guid.Empty)
                Id = club.Id;

            Name = club.Name;
            TimePeriod = club.TimePeriod;
        }

        public ClubDataModel()
        {
        }
    }
}