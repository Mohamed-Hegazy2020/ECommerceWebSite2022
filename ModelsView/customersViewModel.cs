using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.ModelsView
{
    public class customersViewModel
    {
        [Display(Name = "customerName")]
        public string customerName { get; set; }
        [Display(Name = "customerTel")]
        public string customerTel { get; set; }
        [Display(Name = "customerMobile")]
        public string customerMobile { get; set; }
        [Display(Name = "customerAddress")]
        public string customerAddress { get; set; }

    }
}
