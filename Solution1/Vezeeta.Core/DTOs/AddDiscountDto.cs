using System.Text.Json.Serialization;
using Vezeeta.Core.Models;

namespace Vezeeta.Presentation.DTOs
{
    public class AddDiscountDto
    {
        public int Id { get; set; } 
        public string DiscountCode { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DiscountType DiscountType { get; set; }
        public decimal Value { get; set; }
        public int BookingCount { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public string patientId { get; set; }
    }

}
