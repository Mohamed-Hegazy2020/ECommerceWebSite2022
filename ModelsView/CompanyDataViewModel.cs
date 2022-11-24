using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.ModelsView
{
    public class CompanyDataViewModel
    {
        public int id { get; set; }
        [Display(Name = "CompanyNameAr")]
        [Required(ErrorMessage = "CompanyNameArRequerd")]
        public string CompanyNameAr { get; set; }

        [Display(Name = "CompanyNameEn")]
        [Required(ErrorMessage = "CompanyNameEnRequerd")]
        public string CompanyNameEn { get; set; }

        [Display(Name = "AddressAr")]
        [Required(ErrorMessage = "AddressArRequerd")]
        public string AddressAr { get; set; }

        [Display(Name = "AddressEn")]
        [Required(ErrorMessage = "AddressEnRequerd")]
        public string AddressEn { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "EmailRequerd")]
        public string Email { get; set; }

        [Display(Name = "LogoImage")]
        public string LogoImage { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }

        [Display(Name = "FaceBookLink")]
        public string FaceBookLink { get; set; }

        [Display(Name = "TwitterLink")]
        public string TwitterLink { get; set; }

        [Display(Name = "InstgramLink")]
        public string InstgramLink { get; set; }

        [Display(Name = "LinkedinLink")]
        public string LinkedinLink { get; set; }

        [Display(Name = "itemImage")]       
        public IFormFile itemImage { get; set; }

        [Display(Name = "AboutDescreptionAr")]
        public string AboutDescreptionAr { get; set; }

        [Display(Name = "AboutDescreptionEn")]
        public string AboutDescreptionEn { get; set; }
    }
}
