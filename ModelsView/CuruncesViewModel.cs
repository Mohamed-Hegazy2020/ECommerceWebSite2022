using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.ModelsView
{
    public class CuruncesViewModel
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "CuruncyNameAr")]
        [Required(ErrorMessage = "CuruncyNameArRequerd")]
        public string CuruncyNameAr { get; set; }

        [Display(Name = "CuruncyNameEn")]
        [Required(ErrorMessage = "CuruncyNameEnRequerd")]
        public string CuruncyNameEn { get; set; }
        [Display(Name = "isDefualtCuruncy")]
        public bool isDefualtCuruncy { get; set; }
    }
}
