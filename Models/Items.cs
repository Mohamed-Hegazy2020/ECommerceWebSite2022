using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.Models
{
    public class Items
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string itemNameAr { get; set; }
        public string itemNameEn { get; set; }
        public string itemDescreptionAr { get; set; }
        public string itemDescreptionEn { get; set; }
        public int groupId { get; set; }
        public int unitId { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public string itemImgFile { get; set; }
        public int curuncyId { get; set; }
        public int subGroupId { get; set; }
        public bool specialItem { get; set; }
    }
}
