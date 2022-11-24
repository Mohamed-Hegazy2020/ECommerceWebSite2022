using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.ModelsView
{
    public class AdminPanelViewModel
    {
        public int allOrders { get; set; }
        public int newOrders { get; set; }
        public int donOrders { get; set; }
        public int notDonOrders { get; set; }
        public int customers { get; set; }
        public int finshedItems { get; set; }
        public int paidOrders { get; set; }
        public int notPaidOrders { get; set; }

        public List<ItemsViewModel> ItemsViewModel = new List<ItemsViewModel>();
       public List<customersViewModel> customersViewModel = new List<customersViewModel>();

    }
}
