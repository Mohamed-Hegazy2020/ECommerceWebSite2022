using Microsoft.AspNetCore.SignalR;
using MyECommerceWebSite2022.Models;
using MyECommerceWebSite2022.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.Repositores
{
    public class notfyHub : Hub
    {
      
        private readonly shopingDBContext _context;      
        public notfyHub(shopingDBContext context)
        {
           
            _context = context;

        }
        public async Task updateNotfys()
        {
            AdminPanelViewModel p = new AdminPanelViewModel();  
            try
            {
                var orders = _context.InvoiceMaster.ToList();
                var gs = _context.Items.ToList();
                p.allOrders = orders.Count;
                p.donOrders = orders.Where(x => x.IsDeleverd == true).Count();
                p.notDonOrders = orders.Where(x => x.IsDeleverd != true).Count();
                p.newOrders = orders.Where(x => x.IsDeleverd != true).Count();
                p.paidOrders = orders.Where(x => x.IsPayed == true).Count();
                p.notPaidOrders = orders.Where(x => x.IsPayed != true).Count();
                p.finshedItems = gs.Where(x => x.quantity <= 0).Count();
                await Clients.All.SendAsync("updateNotfysClient", p);
            }
            catch (Exception ex)
            {

               
            }
           
        }
    }
}
