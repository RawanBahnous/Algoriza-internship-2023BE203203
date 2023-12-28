using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vezeeta.Core.Models
{
    public class Doctor :ApplicationUser
    {
        [Key]
        public string Id { get; set; }
        public DateTime BirthDate { get; set; }
        public int SpecializeId { get; set; }
        public virtual Specialization Specialize { get; set; }
        public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
       public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
