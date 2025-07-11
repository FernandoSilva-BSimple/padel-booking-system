using System.ComponentModel.DataAnnotations.Schema;
using Domain.Visitor;

namespace Infrastructure.DataModel
{
    [Table("User")]
    public class UserDataModel : IUserVisitor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UserDataModel(IUser user)
        {
            if (user.Id != Guid.Empty)
                Id = user.Id;

            Name = user.Name;
            Email = user.Email;
        }

        public UserDataModel()
        {
        }
    }
}