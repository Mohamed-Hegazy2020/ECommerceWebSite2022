using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.ModelsView
{
    public class SliderViewModel
    {
        [Key]
        public int id { get; set; }
        
        [Required(ErrorMessage = "HedarArRequerd")]
        [Display(Name = "HedarAr")]
        public string HedarAr { get; set; }
        [Display(Name = "HedarEn")]
        public string HedarEn { get; set; }
        [Required(ErrorMessage = "DescreptionArRequerd")]
        [Display(Name = "DescreptionAr")]
        public string DescreptionAr { get; set; }
        [Display(Name = "DescreptionEn")]
        public string DescreptionEn { get; set; }
        [Display(Name = "ImagePath")]
        public string ImagePath { get; set; }
        [Display(Name = "SliderImage")]       
        public IFormFile SliderImage { get; set; }
    }
}
