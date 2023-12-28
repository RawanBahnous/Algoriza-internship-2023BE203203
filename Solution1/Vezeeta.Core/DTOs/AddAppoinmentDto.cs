using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Vezeeta.Core.Models;

namespace Vezeeta.Presentation.DTOs
{
    public class AddAppoinmentDto
    {
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Days Days { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]
        public string DoctorId { get; set; }
        [Required]
        public bool booked { get; set; } = false;
        public List<TimesAppointment> Time { get; set; } = new List<TimesAppointment>();

    }
}
