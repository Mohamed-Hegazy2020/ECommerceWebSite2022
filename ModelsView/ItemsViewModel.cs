using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.ModelsView
{
    public class ItemsViewModel
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "itemNameAr")]
        [Required(ErrorMessage = "itemNameArRequerd")]
        public string itemNameAr { get; set; }

        [Display(Name = "itemNameEn")]
        [Required(ErrorMessage = "itemNameEnRequerd")]
        public string itemNameEn { get; set; }

        [Display(Name = "itemDescreptionAr")]
        public string itemDescreptionAr { get; set; }

        [Display(Name = "itemDescreptionEn")]
        public string itemDescreptionEn { get; set; }

        [Display(Name = "groupId")]
        [Required(ErrorMessage = "groupIdRequerd")]
        public int groupId { get; set; }

        [Display(Name = "unitId")]
        [Required(ErrorMessage = "unitIdRequerd")]
        public int unitId { get; set; }

       
        [Display(Name = "Price")]
        [Required(ErrorMessage = "itemPriceRequerd")]  
        public decimal price { get; set; }

        [Display(Name = "quantity")]
        [Required(ErrorMessage = "itemquantityRequerd")]       
        public decimal quantity { get; set; }

        [Display(Name = "itemImage")]
        [Required(ErrorMessage = "itemImageRequerd")]
        public string itemImgFile { get; set; }

        [Display(Name = "itemImage")]
        //[Required(ErrorMessage = "itemImageRequerd")]
        public IFormFile itemImage { get; set; }

        public int curuncyId { get; set; }

        public string groupName { get; set; }

        public string subGroupName { get; set; }

        public string unitName { get; set; }
        [Display(Name = "CuruncyName")]
        public string curuncyName { get; set; }

        [Display(Name = "subGroupId")]
        public int subGroupId { get; set; }

        [Display(Name = "specialItem")]
        public bool specialItem { get; set; }


    }
}
