using System.ComponentModel.DataAnnotations;

namespace Vezeeta.Core.Models
{
    public class Patient :ApplicationUser
    {
        [Key]
        public string Id { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
        public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public int TotalBookings => Bookings?.Count ?? 0;

    }
}
