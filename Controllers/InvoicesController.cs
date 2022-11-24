using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyECommerceWebSite2022.Models;
using MyECommerceWebSite2022.ModelsView;
using MyECommerceWebSite2022.Repositores;
using System;
using System.Collections.Generic;

using System.Linq;


namespace MyECommerceWebSite2022.Controllers
{
    public class InvoicesController : Controller
    {
        
        private readonly shopingDBContext _context;
        private readonly IHostingEnvironment hosting;
        private readonly ExportToPdf _reportService;
        public InvoicesController( shopingDBContext context, IHostingEnvironment hosting, ExportToPdf reportService)
        {           
            _context = context;
            _reportService = reportService;
            this.hosting = hosting;
           
        }

        // GET: InvoicesController
        public ActionResult Index()
        {
            List<InvoiceMasterViewModel> InvoiceMasterViewModel = new List<InvoiceMasterViewModel>();
            try
            {
                List<InvoiceSearchViewModel> InvoiceSearchViewModel = new List<InvoiceSearchViewModel>();
                InvoiceSearchViewModel.Add(new InvoiceSearchViewModel() { id=0,name="كل الطلبات"});
                InvoiceSearchViewModel.Add(new InvoiceSearchViewModel() { id = 1, name = "طلبات تم تسليمها" });
                InvoiceSearchViewModel.Add(new InvoiceSearchViewModel() { id = 2, name = "طلبات لم يتم تسليمها" });
                InvoiceSearchViewModel.Add(new InvoiceSearchViewModel() { id = 3, name = "طلبات تم دفعها" });
                InvoiceSearchViewModel.Add(new InvoiceSearchViewModel() { id = 4, name = "طلبات لم يتم دفعها" });

                var dfultCurncy = _context.Curunces.Where(x => x.isDefualtCuruncy == true).FirstOrDefault();
                ViewBag.InvoiceSearch = InvoiceSearchViewModel;
                var invs= _context.InvoiceMaster.ToList();
                InvoiceMasterViewModel = invs.Select(x =>
                {
                    InvoiceMasterViewModel l = new InvoiceMasterViewModel();
                    l.id = x.id;
                    l.customerName = x.customerName;
                    l.IsPayed = x.IsPayed;
                    l.invoiceDate = x.invoiceDate;
                    l.IsDeleverd = x.IsDeleverd;
                    l.paymentMethod = x.paymentMethod;
                    l.InvoiceStatus = x.InvoiceStatus;
                    l.customerTel = x.customerTel;
                    l.customerMobile = x.customerMobile;
                    l.customerAddress = x.customerAddress;
                    l.InvoiceTotal = x.InvoiceTotal;
                    l.SearchId = 0;
                    if (dfultCurncy != null)
                    {
                        l.CuruncyName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? dfultCurncy.CuruncyNameEn : dfultCurncy.CuruncyNameAr;
                    }
                    if (x.paymentMethod==100)
                    {
                        l.paymentMethodName = "الدفع عند التسليم";
                    }
                    if (x.paymentMethod == 1)
                    {
                        l.paymentMethodName = "كينت";
                    }
                    if (x.paymentMethod == 6)
                    {
                        l.paymentMethodName = "مدي";
                    }
                    if (x.paymentMethod == 3)
                    {
                        l.paymentMethodName = "أميكس";
                    }
                    if (x.paymentMethod == 11)
                    {
                        l.paymentMethodName = "أبيل";
                    }
                    if (x.paymentMethod == 2)
                    {
                        l.paymentMethodName = "فيزا / ماستر";
                    }
                    if (x.paymentMethod == 5)
                    {
                        l.paymentMethodName = "بنفت";
                    }
                    if (x.paymentMethod == 20)
                    {
                        l.paymentMethodName = "ميزة";
                    }
                    return l;

                }).ToList();
                return View(InvoiceMasterViewModel);
            }
            catch (Exception)
            {

                return View(InvoiceMasterViewModel);
            }
            
        }

        // GET: InvoicesController/Details/5
        public ActionResult Details(int id)
        {
            List<InvoiceDetailsViewModel> InvoiceDetailsViewModel = new List<InvoiceDetailsViewModel>();
            try
            {

                var invs = _context.InvoiceDetailes.Where(x=>x.masterId==id).ToList();
                InvoiceDetailsViewModel = invs.Select(x =>
                {
                    InvoiceDetailsViewModel l = new InvoiceDetailsViewModel();
                    l.id = x.id;
                    l.itemName = x.itemName;
                    l.itemCode = x.itemCode;
                    l.quantity = x.quantity;
                    l.price = x.price; 
                    return l;

                }).ToList();
                return View(InvoiceDetailsViewModel);
            }
            catch (Exception)
            {

                return View(InvoiceDetailsViewModel);
            }
        } 

        // GET: InvoicesController/Edit/5
        public ActionResult Edit(int id)
        {
           InvoiceMasterViewModel  InvoiceMasterViewModel = new  InvoiceMasterViewModel();
            try
            {      
                var invs = _context.InvoiceMaster.Where(x => x.id == id).FirstOrDefault();
                if (invs!=null)
                {
                    InvoiceMasterViewModel.customerName = invs.customerName;
                    InvoiceMasterViewModel.customerMobile = invs.customerMobile;
                    InvoiceMasterViewModel.id = invs.id;
                    InvoiceMasterViewModel.invoiceDate = invs.invoiceDate;
                    InvoiceMasterViewModel.IsPayed = invs.IsPayed;
                    InvoiceMasterViewModel.IsDeleverd = invs.IsDeleverd;
        
                }
        
                return View(InvoiceMasterViewModel);
            }
            catch (Exception)
            {

                return View(InvoiceMasterViewModel);
            }
        }

        // POST: InvoicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InvoiceMasterViewModel InvoiceMasterViewModel)
        {
            try
            {
                if (InvoiceMasterViewModel!=null)
                {
                    using (var t =_context.Database.BeginTransaction())
                    {
                        var inv = _context.InvoiceMaster.Where(x => x.id == id).FirstOrDefault();
                        if (inv != null)
                        {
                            int itmId = 0;
                            inv.IsDeleverd = InvoiceMasterViewModel.IsDeleverd;
                            inv.IsPayed = InvoiceMasterViewModel.IsPayed;

                            var invD = _context.InvoiceDetailes.Where(x=>x.masterId==id).ToList();
                            foreach (var i in invD)
                            {
                                itmId =Convert.ToInt32(i.itemCode);
                                var item = _context.Items.Where(x => x.id == itmId).FirstOrDefault();
                                if (item !=null)
                                {
                                    item.quantity -= i.quantity;
                                }

                            }
                            _context.SaveChanges();
                            t.Commit();
                        }
                    }
            

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchInvoices(int id)
        {
            List<InvoiceMasterViewModel> InvoiceMasterViewModel = new List<InvoiceMasterViewModel>();
            try
            {
                List<InvoiceSearchViewModel> InvoiceSearchViewModel = new List<InvoiceSearchViewModel>();
                InvoiceSearchViewModel.Add(new InvoiceSearchViewModel() { id = 0, name = "كل الطلبات" });
                InvoiceSearchViewModel.Add(new InvoiceSearchViewModel() { id = 1, name = "طلبات تم تسليمها" });
                InvoiceSearchViewModel.Add(new InvoiceSearchViewModel() { id = 2, name = "طلبات لم يتم تسليمها" });
                InvoiceSearchViewModel.Add(new InvoiceSearchViewModel() { id = 3, name = "طلبات تم دفعها" });
                InvoiceSearchViewModel.Add(new InvoiceSearchViewModel() { id = 4, name = "طلبات لم يتم دفعها" });
                ViewBag.InvoiceSearch = InvoiceSearchViewModel;
                var dfultCurncy = _context.Curunces.Where(x => x.isDefualtCuruncy == true).FirstOrDefault();
                List<InvoiceMaster> InvoiceMaster = new List<InvoiceMaster>();
                if (id==0)
                {
                    InvoiceMaster = _context.InvoiceMaster.ToList();
                }
                if (id == 1)
                {
                    InvoiceMaster = _context.InvoiceMaster.Where(x=>x.IsDeleverd==true).ToList();
                }
                if (id == 2)
                {
                    InvoiceMaster = _context.InvoiceMaster.Where(x => x.IsDeleverd == false).ToList();
                }
                if (id == 3)
                {
                    InvoiceMaster = _context.InvoiceMaster.Where(x => x.IsPayed == true).ToList();
                }
                if (id == 4)
                {
                    InvoiceMaster = _context.InvoiceMaster.Where(x => x.IsPayed == false).ToList();
                }
                InvoiceMasterViewModel = InvoiceMaster.Select(x =>
                {
                    InvoiceMasterViewModel l = new InvoiceMasterViewModel();
                    l.id = x.id;
                    l.customerName = x.customerName;
                    l.IsPayed = x.IsPayed;
                    l.invoiceDate = x.invoiceDate;
                    l.IsDeleverd = x.IsDeleverd;
                    l.paymentMethod = x.paymentMethod;
                    l.InvoiceStatus = x.InvoiceStatus;
                    l.customerTel = x.customerTel;
                    l.customerMobile = x.customerMobile;
                    l.customerAddress = x.customerAddress;
                    l.SearchId = id;
                    l.InvoiceTotal = x.InvoiceTotal;
                    if (x.paymentMethod == 100)
                    {
                        l.paymentMethodName = "الدفع عند التسليم";
                    }
                    if (x.paymentMethod == 1)
                    {
                        l.paymentMethodName = "كينت";
                    }
                    if (x.paymentMethod == 6)
                    {
                        l.paymentMethodName = "مدي";
                    }
                    if (x.paymentMethod == 3)
                    {
                        l.paymentMethodName = "أميكس";
                    }
                    if (x.paymentMethod == 11)
                    {
                        l.paymentMethodName = "أبيل";
                    }
                    if (x.paymentMethod == 2)
                    {
                        l.paymentMethodName = "فيزا / ماستر";
                    }
                    if (x.paymentMethod == 5)
                    {
                        l.paymentMethodName = "بنفت";
                    }
                    if (x.paymentMethod == 20)
                    {
                        l.paymentMethodName = "ميزة";
                    }
                    if (dfultCurncy != null)
                    {
                        l.CuruncyName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? dfultCurncy.CuruncyNameEn : dfultCurncy.CuruncyNameAr;
                    }



                    return l;

                }).ToList();

                

                return View("Index", InvoiceMasterViewModel);
            }
            catch (Exception)
            {

                return View("Index", InvoiceMasterViewModel);
            }
        }

        // GET: InvoicesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvoicesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult PrintInvoice(int id)
        {
            PrintInvoiceViewModel p = new PrintInvoiceViewModel();

            var inv = _context.InvoiceMaster.Where(x => x.id == id).FirstOrDefault();
            var invd = _context.InvoiceDetailes.Where(x => x.masterId == id).ToList();
            if (inv!=null)
            {
                var dfultCurncy = _context.Curunces.Where(x => x.isDefualtCuruncy == true).FirstOrDefault();
                p.InvoiceMasterViewModel.customerName = inv.customerName;
                p.InvoiceMasterViewModel.customerAddress = inv.customerAddress;
                p.InvoiceMasterViewModel.customerMobile = inv.customerMobile;
                p.InvoiceMasterViewModel.customerTel = inv.customerTel;
                p.InvoiceMasterViewModel.InvoiceTotal = inv.InvoiceTotal;
                if (dfultCurncy != null)
                {
                    p.InvoiceMasterViewModel.CuruncyName =  System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? dfultCurncy.CuruncyNameEn : dfultCurncy.CuruncyNameAr;
                }
              
            }
            if (invd.Count>0)
            {
                foreach (var item in invd)
                {
                    p.InvoiceDetailsViewModel.Add(new InvoiceDetailsViewModel() {itemCode=item.itemCode,itemName=item.itemName,quantity=item.quantity,price=item.price });

                }

            }
            var html = this.RenderViewAsync("PrintInvoice", p);
            var pdfFile = _reportService.GeneratePdfReport(html.Result);
            return File(pdfFile,"application/octet-stream", "Order.pdf");

        }

        public ActionResult PrintOrders(int id)
        {
            List<InvoiceMasterViewModel> InvoiceMasterViewModel = new List<InvoiceMasterViewModel>();
            try
            {
                List<InvoiceSearchViewModel> InvoiceSearchViewModel = new List<InvoiceSearchViewModel>();
                //InvoiceSearchViewModel.Add(new InvoiceSearchViewModel() { id = 0, name = "كل الطلبات" });
                //InvoiceSearchViewModel.Add(new InvoiceSearchViewModel() { id = 1, name = "طلبات تم تسليمها" });
                //InvoiceSearchViewModel.Add(new InvoiceSearchViewModel() { id = 2, name = "طلبات لم يتم تسليمها" });
                //InvoiceSearchViewModel.Add(new InvoiceSearchViewModel() { id = 3, name = "طلبات تم دفعها" });
                //InvoiceSearchViewModel.Add(new InvoiceSearchViewModel() { id = 4, name = "طلبات لم يتم دفعها" });
                //ViewBag.InvoiceSearch = InvoiceSearchViewModel;
                var dfultCurncy = _context.Curunces.Where(x => x.isDefualtCuruncy == true).FirstOrDefault();
                List<InvoiceMaster> InvoiceMaster = new List<InvoiceMaster>();
                if (id == 0)
                {
                    InvoiceMaster = _context.InvoiceMaster.ToList();
                }
                if (id == 1)
                {
                    InvoiceMaster = _context.InvoiceMaster.Where(x => x.IsDeleverd == true).ToList();
                }
                if (id == 2)
                {
                    InvoiceMaster = _context.InvoiceMaster.Where(x => x.IsDeleverd == false).ToList();
                }
                if (id == 3)
                {
                    InvoiceMaster = _context.InvoiceMaster.Where(x => x.IsPayed == true).ToList();
                }
                if (id == 4)
                {
                    InvoiceMaster = _context.InvoiceMaster.Where(x => x.IsPayed == false).ToList();
                }
                InvoiceMasterViewModel = InvoiceMaster.Select(x =>
                {
                    InvoiceMasterViewModel l = new InvoiceMasterViewModel();
                    l.id = x.id;
                    l.customerName = x.customerName;
                    l.IsPayed = x.IsPayed;
                    l.invoiceDate = x.invoiceDate;
                    l.IsDeleverd = x.IsDeleverd;
                    l.paymentMethod = x.paymentMethod;
                    l.InvoiceStatus = x.InvoiceStatus;
                    l.customerTel = x.customerTel;
                    l.customerMobile = x.customerMobile;
                    l.customerAddress = x.customerAddress;
                    l.SearchId = id;
                    l.InvoiceTotal = x.InvoiceTotal;
                    if (x.paymentMethod == 100)
                    {
                        l.paymentMethodName = "الدفع عند التسليم";
                    }
                    if (x.paymentMethod == 1)
                    {
                        l.paymentMethodName = "كينت";
                    }
                    if (x.paymentMethod == 6)
                    {
                        l.paymentMethodName = "مدي";
                    }
                    if (x.paymentMethod == 3)
                    {
                        l.paymentMethodName = "أميكس";
                    }
                    if (x.paymentMethod == 11)
                    {
                        l.paymentMethodName = "أبيل";
                    }
                    if (x.paymentMethod == 2)
                    {
                        l.paymentMethodName = "فيزا / ماستر";
                    }
                    if (x.paymentMethod == 5)
                    {
                        l.paymentMethodName = "بنفت";
                    }
                    if (x.paymentMethod == 20)
                    {
                        l.paymentMethodName = "ميزة";
                    }
                    if (dfultCurncy != null)
                    {
                        l.CuruncyName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? dfultCurncy.CuruncyNameEn : dfultCurncy.CuruncyNameAr;
                    }

                    return l;

                }).ToList();

                var html = this.RenderViewAsync("PrintOrders", InvoiceMasterViewModel);
                var pdfFile = _reportService.GeneratePdfReport(html.Result);
                return File(pdfFile, "application/octet-stream", "Orders.pdf");
            }
            catch (Exception)
            {
                var html = this.RenderViewAsync("PrintOrders", InvoiceMasterViewModel);
                var pdfFile = _reportService.GeneratePdfReport(html.Result);
                return File(pdfFile, "application/octet-stream", "Orders.pdf");
            }
        }


    }
}
