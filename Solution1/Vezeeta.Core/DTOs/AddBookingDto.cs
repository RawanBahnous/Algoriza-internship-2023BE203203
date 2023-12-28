using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Vezeeta.Core.Models;

namespace Vezeeta.Core.DTOs
{
    public class AddBookingDto
    {
        public Appointment Appointment { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
        public int TotalBookings { get; set; }
        public int FinalPrice { get; set; }
        public  Patient Patient { get; set; }
    }
}
