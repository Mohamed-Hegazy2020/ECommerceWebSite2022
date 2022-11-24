using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.ModelsView
{
    public class UnitsViewModel
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "UnitNameAr")]
        [Required(ErrorMessage = "UnitNameArRequerd")]
        public string UnitNameAr { get; set; }

        [Display(Name = "UnitNameEn")]
        [Required(ErrorMessage = "UnitNameEnRequerd")]
        public string UnitNameEn { get; set; }
    }
}
