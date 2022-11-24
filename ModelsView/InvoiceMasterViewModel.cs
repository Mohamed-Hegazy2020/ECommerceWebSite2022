using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.ModelsView
{
    public class InvoiceMasterViewModel
    {
        [Display(Name = "invoiceNumber")]
        public int id { get; set; }
        [Display(Name = "customerName")]
        public string customerName { get; set; }
        [Display(Name = "customerTel")]
        public string customerTel { get; set; }
        [Display(Name = "customerMobile")]
        public string customerMobile { get; set; }
        [Display(Name = "customerAddress")]
        public string customerAddress { get; set; }
        [Display(Name = "deleverMethod")]
        public int deleverMethod { get; set; }
        [Display(Name = "IsPayed")]
        public bool IsPayed { get; set; }
        [Display(Name = "IsDeleverd")]
        public bool IsDeleverd { get; set; }
        [Display(Name = "paymentMethod")]
        public int paymentMethod { get; set; }
        [Display(Name = "invoiceDate")]
        public DateTime invoiceDate { get; set; }
        [Display(Name = "PaymentURL")]
        public string PaymentURL { get; set; }
        [Display(Name = "PaymentId")]
        public string PaymentId { get; set; }
        [Display(Name = "InvoiceStatus")]
        public string InvoiceStatus { get; set; }
        [Display(Name = "paymentMethodName")]
        public string paymentMethodName { get; set; }
        public int SearchId { get; set; }
        [Display(Name = "InvoiceTotal")]
        public decimal InvoiceTotal { get; set; }
        [Display(Name = "CuruncyName")]
        public string CuruncyName { get; set; }
    }
}
