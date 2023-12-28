using System.ComponentModel.DataAnnotations;
public enum BookingStatus
{
    [Display(Name = "Pending")]
    Pending,

    [Display(Name = "Completed")]
    Completed,

    [Display(Name = "Canceled")]
    Canceled
}