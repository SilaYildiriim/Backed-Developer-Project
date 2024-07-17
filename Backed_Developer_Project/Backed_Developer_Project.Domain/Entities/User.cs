using Backed_Developer_Project.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Backed_Developer_Project.Domain.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            Forms = new List<Form>();
        }

        public string UserName { get; set; }
        public string Password { get; set; }

        // Nav Prop
        public ICollection<Form> Forms { get; set; }
    }
}
