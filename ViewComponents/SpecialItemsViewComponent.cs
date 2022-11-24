using Microsoft.AspNetCore.Mvc;
using MyECommerceWebSite2022.Models;
using MyECommerceWebSite2022.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.ViewComponents
{
    [ViewComponent(Name = "SpecialItemsViewComponent")]
    public class SpecialItemsViewComponent : ViewComponent
    {
        private readonly shopingDBContext _context;
        List<ItemsViewModel> ItemsViewModelView = new List<ItemsViewModel>();
        public SpecialItemsViewComponent(shopingDBContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var itms = _context.Items.Where(x=>x.specialItem==true).ToList();
            var dfultCurncy = _context.Curunces.Where(x => x.isDefualtCuruncy == true).FirstOrDefault();
            string curuncyName = "";
            if (dfultCurncy != null)
            {
                 curuncyName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? dfultCurncy.CuruncyNameEn : dfultCurncy.CuruncyNameAr;
            }
            foreach (var item in itms)
            {
                ItemsViewModelView.Add(new ItemsViewModel()
                {
                    id = item.id,
                    itemNameAr = item.itemNameAr,
                    itemImgFile = item.itemImgFile,
                    itemDescreptionAr = item.itemDescreptionAr,
                    itemDescreptionEn = item.itemDescreptionEn,
                    price = item.price,
                    curuncyName= curuncyName,
                });
            }
            var model = ItemsViewModelView;
            return await Task.FromResult((IViewComponentResult)View("SpecialItemsViewComponent", model));
        }

    }
}
