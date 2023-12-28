using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Vezeeta.Core.Models;

namespace Vezeeta.Core.DTOs
{
    public class BookingDto
    {

        public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
        public int TotalBookings { get; set; }
        public int FinalPrice { get; set; }
        public virtual AppoinmentDto Appointment { get; set; }
        public virtual PatientDto Patient { get; set; }
    }
}
