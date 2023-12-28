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
    public class DiscountDto
    {
        public int Id { get; set; }
        public string DiscountCode { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DiscountType DiscountType { get; set; }
        [Required]
        public decimal Value { get; set; }
        public int BookingCount { get; set; }
        public bool IsActive { get; set; }
    }

}
