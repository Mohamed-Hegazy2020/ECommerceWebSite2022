using Microsoft.AspNetCore.Mvc;
using MyECommerceWebSite2022.Models;
using MyECommerceWebSite2022.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.ViewComponents
{
    [ViewComponent(Name = "ItemsViewModel")]
    public class ItemsViewModelViewComponent : ViewComponent
    {
        private readonly shopingDBContext _context;
        List<ItemsViewModel> ItemsViewModelView = new List<ItemsViewModel>();
        public ItemsViewModelViewComponent(shopingDBContext context)
        {
            _context = context;
           
           
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var itms = _context.Items.Where(x=>x.groupId==id).ToList();
            foreach (var item in itms)
            {
                ItemsViewModelView.Add(new ItemsViewModel() { id = item.id, itemNameAr = item.itemNameAr, itemImgFile = item.itemImgFile,itemDescreptionAr=item.itemDescreptionAr,
                    itemDescreptionEn = item.itemDescreptionEn,price=item.price
                });
            }
            var model = ItemsViewModelView;
            return await Task.FromResult((IViewComponentResult)View("ItemsViewModel", model));
        }
    }
}
