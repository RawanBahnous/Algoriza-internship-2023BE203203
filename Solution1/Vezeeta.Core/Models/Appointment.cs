using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vezeeta.Core.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Days Days { get; set; }

        [Required]
        public decimal Price { get; set; }
        public bool booked { get; set; } = false;
        public string DoctorId { get; set; }
        [JsonIgnore]
        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<TimesAppointment> Time { get; set; } = new List<TimesAppointment>();
        public virtual ICollection<DiscountAppointment> DiscountAppointment { get; set; } = new List<DiscountAppointment>();

    }

}
