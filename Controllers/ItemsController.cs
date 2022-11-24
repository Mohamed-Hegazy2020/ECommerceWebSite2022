using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyECommerceWebSite2022.Models;
using MyECommerceWebSite2022.ModelsView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.Controllers
{
    public class ItemsController : Controller
    {
        public List<Groups> groups;
        public List<Groups> subGroupId;
        public List<Units> Units;
        private readonly shopingDBContext _context;
        private readonly IHostingEnvironment hosting;
        public ItemsController(shopingDBContext context, IHostingEnvironment hosting)
        {
            _context = context;
            this.hosting = hosting;
        }
        // GET: ItemsController
        public ActionResult Index(int searchTyp)
        {
            List<ItemsViewModel> g = new List<ItemsViewModel>();
            try
            {
                var gs = _context.Items.ToList();
                g = gs.Select(x =>
                {
                    ItemsViewModel l = new ItemsViewModel();
                    l.id = x.id;
                    l.itemNameAr = x.itemNameAr;
                    l.itemNameEn = x.itemNameEn;
                    l.itemDescreptionAr = x.itemDescreptionAr;
                    l.itemDescreptionEn = x.itemDescreptionEn;
                    l.quantity = x.quantity;
                    //l.unitId = x.unitId;
                    l.price = x.price;
                    l.itemImgFile = x.itemImgFile;

                    var unt = _context.Units.Find(x.unitId);
                    if (unt!=null)
                    {
                        l.unitName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? unt.UnitNameEn : unt.UnitNameAr;
                    }
                    var grop = _context.Groups.Find(x.groupId);
                    if (grop !=null)
                    {
                        l.groupName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? grop.GroupNameEn : grop.GroupNameAr;

                    }
                    var crncy = _context.Curunces.Where(x=>x.isDefualtCuruncy==true).FirstOrDefault();
                    if (grop != null)
                    {
                        l.curuncyName = crncy!=null?(System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? crncy.CuruncyNameEn : crncy.CuruncyNameAr):"";

                    }
                    return l;

                }).ToList();
                if (searchTyp>0 && searchTyp==5 )
                {
                    g = g.Where(x=>x.quantity<=0).ToList();
                }
                return View(g);

            }
            catch (Exception)
            {
                return View(g);

            }
        }

        // GET: ItemsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemsController/Create
        public ActionResult Create()
        {
            try
            {
                groups = new List<Groups>();
                subGroupId = new List<Groups>();
                Units = new List<Units>();
                groups = _context.Groups.Where(x => x.IsMainGroup == true).ToList();
                subGroupId = _context.Groups.Where(x => x.IsMainGroup == false).ToList();
                subGroupId.Insert(0, new Groups() { id = 0, GroupNameAr = "", GroupNameEn = "" });
                Units = _context.Units.ToList();
                ViewBag.groups = groups;
                ViewBag.subGroupId = subGroupId;
                ViewBag.Units = Units;
            }
            catch (Exception)
            {


            }
            return View();
        }

        // POST: ItemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemsViewModel u)
        {
            try
            {
                string ImageName = "";
                if (u.itemImage != null)
                {
                    string uploads = Path.Combine(hosting.WebRootPath, "ItemsImages");
                    ImageName = u.itemImage.FileName;
                    string fullPath = Path.Combine(uploads, ImageName);
                    //string oldPath = Path.Combine(uploads, u.itemImgFile != null ? u.itemImgFile : "");
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                        u.itemImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }
                    else
                    {
                        u.itemImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }

                }
                var dfultCurncy = _context.Curunces.Where(x=>x.isDefualtCuruncy==true).FirstOrDefault();
                Items unt = new Items
                {

                    itemNameAr = u.itemNameAr,
                    itemNameEn = u.itemNameEn,
                    itemDescreptionAr = u.itemDescreptionAr,
                    itemDescreptionEn = u.itemDescreptionEn,
                    quantity = u.quantity,
                    unitId = u.unitId,
                    price = u.price,
                    groupId = u.groupId,
                    subGroupId=u.subGroupId,
                    specialItem=u.specialItem,
                    curuncyId= dfultCurncy !=null? dfultCurncy.id:0,
                    itemImgFile = ImageName
                };
                _context.Items.Add(unt);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemsController/Edit/5
        public ActionResult Edit(int id)
        {
            var unt = new ItemsViewModel();
            try
            {
                subGroupId = new List<Groups>();
                groups = new List<Groups>();
                Units = new List<Units>();
                groups = _context.Groups.Where(x => x.IsMainGroup == true).ToList();
                subGroupId = _context.Groups.Where(x => x.IsMainGroup == false).ToList();
                subGroupId.Insert(0, new Groups() { id = 0, GroupNameAr = "", GroupNameEn = "" });

                Units = _context.Units.ToList();
                ViewBag.groups = groups;
                ViewBag.subGroupId = subGroupId;
                ViewBag.Units = Units;
                var u = _context.Items.Find(id);
                if (u != null)
                {
                    unt.id = u.id;
                    unt.itemNameAr = u.itemNameAr;
                    unt.itemNameEn = u.itemNameEn;
                    unt.itemDescreptionAr = u.itemDescreptionAr;
                    unt.itemDescreptionEn = u.itemDescreptionEn;
                    unt.groupId = u.groupId;
                    unt.subGroupId = u.subGroupId;
                    unt.unitId = u.unitId;
                    unt.price = u.price;
                    unt.quantity = u.quantity;
                    unt.itemImgFile = u.itemImgFile;
                    unt.specialItem = u.specialItem;
                    //unt.itemImage = GetFile(u.itemImgFile);

                }
                return View(unt);
            }
            catch (Exception)
            {

                return View(unt);
            }
        }

        public IFormFile GetFile(string imageName)
        {
            string uploads = Path.Combine(hosting.WebRootPath, "ItemsImages");
            string path = Path.Combine(uploads, imageName);            
            using (var stream = System.IO.File.OpenRead(path))
            {

                return new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
              
              
            };

        }

        // POST: ItemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ItemsViewModel u)
        {
            try
            {

                string ImageName = "";
                if (u.itemImage != null)
                {
                    string uploads = Path.Combine(hosting.WebRootPath, "ItemsImages");
                    ImageName = u.itemImage.FileName;
                    string fullPath = Path.Combine(uploads, ImageName);
                    //string oldPath = Path.Combine(uploads, u.itemImgFile != null ? u.itemImgFile : "");
                    if (System.IO.File.Exists(fullPath))
                    {
                        //System.IO.File.Delete(fullPath);
                        //u.itemImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }
                    else
                    {
                        u.itemImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }

                }
                var dfultCurncy = _context.Curunces.Where(x => x.isDefualtCuruncy == true).FirstOrDefault();
                var olditm = _context.Items.Find(id);
                olditm.itemNameAr = u.itemNameAr;
                olditm.itemNameEn = u.itemNameEn;
                olditm.itemDescreptionAr = u.itemDescreptionAr;
                olditm.itemDescreptionEn = u.itemDescreptionEn;
                olditm.groupId = u.groupId;
                olditm.subGroupId = u.subGroupId;
                olditm.unitId = u.unitId;
                olditm.price = u.price;
                olditm.quantity = u.quantity;
                olditm.specialItem = u.specialItem;
                olditm.itemImgFile = ImageName != "" ? ImageName : olditm.itemImgFile;
                olditm.curuncyId = dfultCurncy != null ? dfultCurncy.id : olditm.curuncyId;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            try
            {
                var g = _context.Items.Find(id);
                _context.Items.Remove(g);
                string ImageName = g.itemImgFile;
                if (_context.SaveChanges() > 0)
                {
                    if (ImageName != null)
                    {
                        string uploads = Path.Combine(hosting.WebRootPath, "ItemsImages");
                        string fullPath = Path.Combine(uploads, ImageName);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);

                        }

                    }

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }


        public JsonResult GetSubGroupsByMainGruopId(int mainGropId)
        {
            List<Groups> groups = new List<Groups>();
            try
            {
                groups = new List<Groups>();
                groups = _context.Groups.Where(x => x.IsMainGroup == false && x.mainGroupId== mainGropId).ToList();
                groups.Insert(0, new Groups() { id = 0, GroupNameAr = "كل الأقسام", GroupNameEn = "All" });
                return Json(groups);
            }
            catch (Exception)
            {
                return Json(groups);

            }
        }
    }
}
