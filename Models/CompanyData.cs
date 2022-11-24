using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.Models
{
    public class CompanyData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "CompanyName")]
        [Required(ErrorMessage = "CompanyNameAr")]
        public string CompanyNameAr { get; set; }
        public string CompanyNameEn { get; set; }
        public string AddressAr { get; set; }
        public string AddressEn { get; set; }
        public string Email { get; set; }
        public string LogoImage { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string FaceBookLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstgramLink { get; set; }
        public string LinkedinLink { get; set; }
        public string AboutDescreptionAr { get; set; }
        public string AboutDescreptionEn { get; set; }
    }
}
