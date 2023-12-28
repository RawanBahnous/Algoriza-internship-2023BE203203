namespace Vezeeta.Core.Models
{
    public class DiscountAppointment
    {
        public int Id { get; set; }
        public int DiscountId { get; set; }
        public virtual Discount Discount { get; set; }
        public int AppoinmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
