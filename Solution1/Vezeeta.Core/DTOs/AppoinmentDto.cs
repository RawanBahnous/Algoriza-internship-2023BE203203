using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Vezeeta.Core.Models;

namespace Vezeeta.Core.DTOs
{
    public class AppoinmentDto
    {
        public int Id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Days Days { get; set; }
        public decimal Price { get; set; }
        public string DoctorId { get; set; }
        //[JsonIgnore]
        public Doctor Doctor { get; set; }
        public bool booked { get; set; }

    }

}