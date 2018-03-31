using System.ComponentModel.DataAnnotations;

namespace BilgeAdam.Northwind.Business.Enums
{
    public enum Gender
    {
        [Display(Name = "Belirtilmemiş")]
        NotSet = 0,
        [Display(Name = "Erkek")]
        Male = 1,
        [Display(Name = "Kadın")]
        Female = 2
    }
}
