using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.ModelsView
{
    public class PrintInvoiceViewModel
    {
        public InvoiceMasterViewModel InvoiceMasterViewModel = new InvoiceMasterViewModel();
        public List<InvoiceDetailsViewModel> InvoiceDetailsViewModel = new List<InvoiceDetailsViewModel>();
    }
}
