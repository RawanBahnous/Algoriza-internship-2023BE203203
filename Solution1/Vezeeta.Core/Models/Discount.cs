using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Vezeeta.Core.Models;
using System.Text.Json.Serialization;

public class Discount
{
    [Key]
    public int Id { get; set; }
    public string DiscountCode { get; set; }
    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DiscountType DiscountType { get; set; }
    [Required]
    public decimal Value { get; set; }
    public int BookingCount { get; set; }
    public bool IsActive { get; set; }

    //[ForeignKey("PatientId")]
    //public string PatientId { get; set; }
    [JsonIgnore]
    public virtual Patient Patient { get; set; }
    public virtual ICollection<DiscountAppointment> DiscountAppointment { get; set; } = new List<DiscountAppointment>();
}
