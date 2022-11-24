using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.Models
{
    public class InvoiceDetailes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int masterId { get; set; }
        public int invNo { get; set; }
        //public string customerName { get; set; }
        //public string customerTel { get; set; }
        //public string customerMobile { get; set; }
        //public string customerAddress { get; set; }
        public string itemName { get; set; }
        public string itemCode { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public bool IsViewed { get; set; }
    }
}
