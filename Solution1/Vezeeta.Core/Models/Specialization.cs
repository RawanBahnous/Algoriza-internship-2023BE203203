using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vezeeta.Core.Models
{
    public class Specialization
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Doctor>? Doctors { get; set; } = new List<Doctor>();

        public string? AdminId { get; set; }

        public virtual Admin Admin { get; set; }
    }
}
