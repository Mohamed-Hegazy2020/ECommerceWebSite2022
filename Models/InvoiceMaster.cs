using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.Models
{
    public class InvoiceMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }   
        public int InvoiceId { get; set; }      
        public string customerName { get; set; }
        public string customerTel { get; set; }
        public string customerMobile { get; set; }
        public string customerAddress { get; set; }       
        public int deleverMethod { get; set; }
        public int paymentMethod { get; set; }
        public bool IsPayed { get; set; }
        public bool IsDeleverd { get; set; }
        public DateTime invoiceDate { get; set; }
        public string PaymentURL { get; set; }
        public string PaymentId { get; set; }
        public string InvoiceStatus { get; set; }
        public decimal InvoiceTotal { get; set; }
    }
}
