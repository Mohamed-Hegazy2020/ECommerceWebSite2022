using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.Models
{
    public class Groups
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string GroupNameAr { get; set; }
        public string GroupNameEn { get; set; }
        public string GroupImgFile { get; set; }
        public bool IsMainGroup { get; set; }
        public int mainGroupId { get; set; }
    }
}
