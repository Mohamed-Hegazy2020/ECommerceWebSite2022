using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyECommerceWebSite2022.Models;
using MyECommerceWebSite2022.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.Controllers
{
    public class UserController : Controller
    {
        public List<Groups> groups;
        public List<Groups> subGroups;
        private readonly shopingDBContext _context;
        static string token = "rLtt6JWvbUHDDhsZnfpAhpYk4dxYDQkbcPTyGaKp2TYqQgG7FGZ5Th_WD53Oq8Ebz6A53njUoo1w3pjU1D4vs_ZMqFiz_j0urb_BH9Oq9VZoKFoJEDAbRZepGcQanImyYrry7Kt6MnMdgfG5jn4HngWoRdKduNNyP4kzcp3mRv7x00ahkm9LAK7ZRieg7k1PDAnBIOG3EyVSJ5kK4WLMvYr7sCwHbHcu4A5WwelxYK0GMJy37bNAarSJDFQsJ2ZvJjvMDmfWwDVFEVe_5tOomfVNt6bOg9mexbGjMrnHBnKnZR1vQbBtQieDlQepzTZMuQrSuKn-t5XZM7V6fCW7oP-uXGX-sMOajeX65JOf6XVpk29DP6ro8WTAflCDANC193yof8-f5_EYY-3hXhJj7RBXmizDpneEQDSaSz5sFk0sV5qPcARJ9zGG73vuGFyenjPPmtDtXtpx35A-BVcOSBYVIWe9kndG3nclfefjKEuZ3m4jL9Gg1h2JBvmXSMYiZtp9MR5I6pvbvylU_PP5xJFSjVTIz7IQSjcVGO41npnwIxRXNRxFOdIUHn0tjQ-7LwvEcTXyPsHXcMD8WtgBh-wxR8aKX7WPSsT1O8d8reb2aR7K3rkV3K82K_0OgawImEpwSvp9MNKynEAJQS6ZHe_J_l77652xwPNxMRTMASk1ZsJL";
        static string baseURL = "https://apitest.myfatoorah.com";
        public UserController(shopingDBContext context)
        {
            _context = context;

        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Groups> itms = new List<Groups>();
            List<GroupsViewModel> Groupsitms = new List<GroupsViewModel>();
            try
            {

                itms = _context.Groups.Where(x=>x.IsMainGroup==true).ToList();
                var sliders = _context.Slider.ToList();

                foreach (var item in itms)
                {
                    Groupsitms.Add(new GroupsViewModel() { id = item.id, GroupNameAr = item.GroupNameAr, GroupNameEn = item.GroupNameEn, GroupImgFile = item.GroupImgFile, Sliders = sliders });

                }

                return View(Groupsitms);
            }
            catch (Exception)
            {
                return View(Groupsitms);
            }
        }

        /////////////بحث الاصناف برقم المجموعة////////////////
        public ActionResult Prouducts(int id, int id2)
        {
            List<ItemsViewModel> itms = new List<ItemsViewModel>();
            try
            {
                groups = new List<Groups>();
                groups = _context.Groups.Where(x => x.IsMainGroup == true).ToList();
                groups.Insert(0, new Groups() { id = 0, GroupNameAr = "كل الأقسام", GroupNameEn = "All" });

                subGroups = new List<Groups>();               
                var dfultCurncy = _context.Curunces.Where(x => x.isDefualtCuruncy == true).FirstOrDefault();
                ViewBag.groups = groups.OrderBy(o => o.id).ToList();
                string subGroupName = "";
                if (id == 0)
                {
                    subGroups = _context.Groups.Where(x => x.IsMainGroup==false).ToList();
                    subGroups.Insert(0, new Groups() { id = 0, GroupNameAr = "كل الفروع", GroupNameEn = "" });
                    ViewBag.subGroups = subGroups.OrderBy(o => o.id).ToList();
                    List<Items> itmsss = _context.Items.ToList();//Where(x => x.groupId == id).
                    if (id2 > 0)
                    {
                        itmsss = itmsss.Where(x => x.subGroupId == id2).ToList();
                        var subGrop = _context.Groups.Where(g => g.id == id2).FirstOrDefault();
                        if (subGrop != null)
                        {
                            subGroupName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? subGrop.GroupNameEn : subGrop.GroupNameAr;

                        }
                    }
                    itms = itmsss.Select(x =>
                    {
                        ItemsViewModel l = new ItemsViewModel();
                        l.id = x.id;
                        l.itemNameAr = x.itemNameAr;
                        l.itemNameEn = x.itemNameEn;
                        l.itemDescreptionAr = x.itemDescreptionAr;
                        l.itemDescreptionEn = x.itemDescreptionEn;
                        l.price = x.price;
                        l.groupName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? "All Departement " : "كل الأقسام";
                        l.subGroupName = subGroupName;
                        l.groupId = 0;
                        l.itemImgFile = x.itemImgFile;
                        l.subGroupId = x.subGroupId;
                        if (dfultCurncy != null)
                        {
                            l.curuncyName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? dfultCurncy.CuruncyNameEn : dfultCurncy.CuruncyNameAr;
                        }
                        return l;
                    }).OrderBy(o => o.subGroupId).ToList();

                }
                else
                {
                    subGroups = _context.Groups.Where(x => x.mainGroupId == id).ToList();
                    subGroups.Insert(0, new Groups() { id = 0, GroupNameAr = "كل الفروع", GroupNameEn = "" });
                    ViewBag.subGroups = subGroups.OrderBy(o => o.id).ToList();
                    List<Items> itmsss = _context.Items.Where(x => x.groupId == id).ToList();
                    if (id2>0)
                    {
                        itmsss = itmsss.Where(x=>x.subGroupId==id2).ToList();
                        var subGrop = _context.Groups.Where(g => g.id == id2).FirstOrDefault();
                        if (subGrop != null)
                        {
                            subGroupName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? subGrop.GroupNameEn : subGrop.GroupNameAr;

                        }
                    }
                    itms = itmsss.Select(x =>
                    {
                        ItemsViewModel l = new ItemsViewModel();
                        l.id = x.id;
                        l.itemNameAr = x.itemNameAr;
                        l.itemNameEn = x.itemNameEn;
                        l.itemDescreptionAr = x.itemDescreptionAr;
                        l.itemDescreptionEn = x.itemDescreptionEn;
                        l.price = x.price;
                        l.groupName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? "  Departement Of  " + _context.Groups.Where(g => g.id == x.groupId).FirstOrDefault().GroupNameEn : "  قسم  " + _context.Groups.Where(g => g.id == x.groupId).FirstOrDefault().GroupNameAr;
                        l.subGroupName = subGroupName;
                        l.groupId = x.groupId;
                        l.itemImgFile = x.itemImgFile;
                        l.subGroupId = x.subGroupId;
                        if (dfultCurncy != null)
                        {
                            l.curuncyName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? dfultCurncy.CuruncyNameEn : dfultCurncy.CuruncyNameAr;
                        }
                        return l;
                    }).OrderBy(o => o.subGroupId).ToList();

                }

                return View(itms);
            }
            catch (Exception ex)
            {
                return View(itms);
            }

        }

        /////////////بحث الاصناف برقم الصنف////////////////
        public ActionResult ProuductDetails(int id)
        {
            ItemsViewModel itms = new ItemsViewModel();
            try
            {                
                     
                if (id > 0)
                {
                    var dfultCurncy = _context.Curunces.Where(x => x.isDefualtCuruncy == true).FirstOrDefault();                   
                    var itmsss = _context.Items.Where(x => x.id == id).FirstOrDefault();
                    var unt = _context.Units.AsEnumerable().Where(x => x.id == itmsss.unitId).FirstOrDefault();


                    itms.id = itmsss.id;
                    itms.itemNameAr = itmsss.itemNameAr;
                    itms.itemNameEn = itmsss.itemNameEn;
                    itms.itemDescreptionAr = itmsss.itemDescreptionAr;
                    itms.itemDescreptionEn = itmsss.itemDescreptionEn;
                    itms.price = itmsss.price;
                    itms.groupName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? "  Departement Of  " + _context.Groups.Where(g => g.id == itmsss.groupId).FirstOrDefault().GroupNameEn : "  قسم  " + _context.Groups.Where(g => g.id == itmsss.groupId).FirstOrDefault().GroupNameAr;
                    itms.groupId = itmsss.groupId;
                    itms.itemImgFile = itmsss.itemImgFile;
                    itms.quantity = itmsss.quantity;
                   
                    if (dfultCurncy != null)
                    {
                        itms.curuncyName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? dfultCurncy.CuruncyNameEn : dfultCurncy.CuruncyNameAr;
                    }
                    if (unt != null)
                    {
                        itms.unitName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? unt.UnitNameEn : unt.UnitNameAr;
                    }


                }

                return View(itms);
            }
            catch (Exception ex)
            {
                return View(itms);
            }

        }

        /////////////بحث الاصناف برقم الصنف////////////////
        public JsonResult GetItemById(int id)
        {
            ItemsViewModel itms = new ItemsViewModel();
            try
            {

                if (id > 0)
                {
                    var dfultCurncy = _context.Curunces.Where(x => x.isDefualtCuruncy == true).FirstOrDefault();
                    var itmsss = _context.Items.Where(x => x.id == id).FirstOrDefault();
                    var unt = _context.Units.AsEnumerable().Where(x => x.id == itmsss.unitId).FirstOrDefault();
                    itms.id = itmsss.id;
                    itms.itemNameAr = itmsss.itemNameAr;
                    itms.itemNameEn = itmsss.itemNameEn;
                    itms.itemDescreptionAr = itmsss.itemDescreptionAr;
                    itms.itemDescreptionEn = itmsss.itemDescreptionEn;
                    itms.price = itmsss.price;
                    itms.groupName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? "  Departement Of  " + _context.Groups.Where(g => g.id == itmsss.groupId).FirstOrDefault().GroupNameEn : "  قسم  " + _context.Groups.Where(g => g.id == itmsss.groupId).FirstOrDefault().GroupNameAr;
                    itms.groupId = itmsss.groupId;
                    itms.itemImgFile = itmsss.itemImgFile;
                    itms.quantity = itmsss.quantity;
                    if (dfultCurncy != null)
                    {
                        itms.curuncyName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? dfultCurncy.CuruncyNameEn : dfultCurncy.CuruncyNameAr;
                    }
                    if (unt != null)
                    {
                        itms.unitName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? unt.UnitNameEn : unt.UnitNameAr;
                    }

                }

                return Json(itms);
            }
            catch (Exception ex)
            {
                return Json(itms);
            }

        }

        [HttpGet]
        public ActionResult Categories()
        {
            List<Groups> itms = new List<Groups>();
            List<GroupsViewModel> Groupsitms = new List<GroupsViewModel>();
            try
            {

                itms = _context.Groups.Where(x => x.IsMainGroup == true).ToList();               

                foreach (var item in itms)
                {
                    Groupsitms.Add(new GroupsViewModel() { id = item.id, GroupNameAr = item.GroupNameAr, GroupNameEn = item.GroupNameEn, GroupImgFile = item.GroupImgFile});

                }

                return View(Groupsitms);
            }
            catch (Exception)
            {
                return View(Groupsitms);
            }
        }

        [HttpGet]
        public ActionResult Invoice()
        {
            return View();
        }


        public ActionResult About()
        {
            CompanyDataViewModel cv = new CompanyDataViewModel();
            try
            {
                var c = _context.CompanyDatas.FirstOrDefault();
                if (c != null)
                {
                    cv.AboutDescreptionAr = c.AboutDescreptionAr;
                    cv.AboutDescreptionEn = c.AboutDescreptionEn;                   

                }

                return View(cv);

            }
            catch (Exception)
            {
                return View(cv);

            }
        }



    }
}
