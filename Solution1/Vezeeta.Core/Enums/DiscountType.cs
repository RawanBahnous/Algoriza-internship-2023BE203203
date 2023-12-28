using System.ComponentModel.DataAnnotations;
public enum DiscountType
{
    [Display(Name = "Percentage")]
    Percentage,

    [Display(Name = "FixedAmount")]
    FixedAmount
}