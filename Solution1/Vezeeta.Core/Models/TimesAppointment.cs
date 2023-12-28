using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vezeeta.Core.Models
{
    public class TimesAppointment
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public int AppointmentId { get; set; }
        [JsonIgnore]
        public virtual Appointment Appointment { get; set;}
    }
}
