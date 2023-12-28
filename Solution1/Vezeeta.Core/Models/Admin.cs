using System.ComponentModel.DataAnnotations;

namespace Vezeeta.Core.Models
{
    public class Admin : ApplicationUser
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
        public virtual ICollection<Specialization> Specializations { get; set; } = new List<Specialization>();
        public virtual ICollection<Booking> BookingAppointments { get; set; } = new List<Booking>();
        public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();

    }
}
