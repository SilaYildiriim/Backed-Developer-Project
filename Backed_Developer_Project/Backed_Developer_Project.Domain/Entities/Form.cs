
using Backed_Developer_Project.Domain.Enums;

namespace Backed_Developer_Project.Domain.Entities
{
    public class Form 
    {
        public Form()
        {
            FormFields = new List<FormField>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        // Nav Prop
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<FormField> FormFields { get; set; }

    }
}
