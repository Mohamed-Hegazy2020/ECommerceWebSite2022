using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.Models
{
    public class Units
    {
        [Key]
        public int id { get; set; }
        public string UnitNameAr { get; set; }
        public string UnitNameEn { get; set; }
    }
}
