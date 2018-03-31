using System.ComponentModel.DataAnnotations;

namespace BilgeAdam.Northwind.Business.Enums
{
    public enum MarrialStatus
    {
        [Display(Name = "Belirtilmemiş")]
        NotSet = 0,
        [Display(Name = "Evli")]
        Married = 1,
        [Display(Name = "Bekâr")]
        Single = 2
    }
}
