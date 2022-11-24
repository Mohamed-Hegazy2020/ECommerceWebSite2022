using Microsoft.AspNetCore.Http;
using MyECommerceWebSite2022.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.ModelsView
{
    public class GroupsViewModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "GroupNameAr")]
        [Required(ErrorMessage = "GroupNameArRequerd")]
        public string GroupNameAr { get; set; }

        [Display(Name = "GroupNameEn")]
        public string GroupNameEn { get; set; }

        [Display(Name = "GroupImgFile")]
        public string GroupImgFile { get; set; }

        [Display(Name = "itemImage")]
        //[Required(ErrorMessage = "itemImageRequerd")]
        public IFormFile itemImage { get; set; }

        [Display(Name = "IsMainGroup")]
        public bool IsMainGroup { get; set; }
        
        [Display(Name = "mainGroupId")]
        public int mainGroupId { get; set; }


        public List<Slider> Sliders = new List<Slider>();
    }
}
