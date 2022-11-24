using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.ModelsView
{
    public class InvoiceDetailsViewModel
    {
        public int id { get; set; }       
        public int masterId { get; set; }       
        public int invNo { get; set; }
        //public string customerName { get; set; }
        //public string customerTel { get; set; }
        //public string customerMobile { get; set; }
        //public string customerAddress { get; set; }
        [Display(Name = "itemNameAr")]
        public string itemName { get; set; }
        [Display(Name = "ItemCode")]
        public string itemCode { get; set; }
        [Display(Name = "Price")]
        public decimal price { get; set; }
        [Display(Name = "quantity")]
        public decimal quantity { get; set; }
        public bool IsViewed { get; set; }
    }
}
