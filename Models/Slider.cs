using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.Models
{
    public class Slider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string HedarAr { get; set; }
        public string HedarEn { get; set; }
        public string DescreptionAr { get; set; }
        public string DescreptionEn { get; set; }
        public string ImagePath { get; set; }

    }
}
