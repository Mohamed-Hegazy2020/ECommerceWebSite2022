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
   
    public class GroupsController : Controller
    {
        public List<Groups> mainGroups;
        private readonly shopingDBContext _context;
        private readonly IHostingEnvironment hosting;
        public GroupsController(shopingDBContext context, IHostingEnvironment hosting)
        {           
            _context = context;
            this.hosting = hosting;
        }
        // GET: GroupsController
        public ActionResult Index()
        {
           List<GroupsViewModel> g = new List<GroupsViewModel>();
            try
            {
                var gs = _context.Groups.ToList();
                g = gs.Select(x=> 
                {
                    GroupsViewModel l= new GroupsViewModel();
                    l.id = x.id;
                    l.GroupNameAr = x.GroupNameAr;
                    l.GroupNameEn = x.GroupNameEn;
                    l.GroupImgFile = x.GroupImgFile;

                    return l;

                }).ToList();
                return View(g);

            }
            catch (Exception)
            {
                return View(g);

            }
           
        }

        // GET: GroupsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GroupsController/Create
        public ActionResult Create()
        {
            try
            {
                mainGroups = new List<Groups>();
                mainGroups = _context.Groups.Where(x=>x.IsMainGroup==true).ToList();
                mainGroups.Insert(0,new Groups() { id=0,GroupNameAr="",GroupNameEn=""});
                ViewBag.mainGroups = mainGroups;
                return View();
            }
            catch (Exception)
            {
                return View();

            }
           
        }

        // POST: GroupsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GroupsViewModel u)
        {
            try
            {
                string ImageName = "";
                if (u.itemImage != null)
                {
                    string uploads = Path.Combine(hosting.WebRootPath, "GroupImages");
                    ImageName = u.itemImage.FileName;
                    string fullPath = Path.Combine(uploads, ImageName);
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

                Groups unt = new Groups
                {
                    //id = u.id,
                    GroupNameAr = u.GroupNameAr,
                    GroupNameEn=u.GroupNameEn,
                    IsMainGroup=u.IsMainGroup,
                    mainGroupId= u.IsMainGroup ==true?0:u.mainGroupId,
                    GroupImgFile = ImageName,
                };
                _context.Groups.Add(unt);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var gv = new GroupsViewModel();
            try
            {
               
                var g = _context.Groups.Find(id);
                if (g!=null)
                {
                    mainGroups = new List<Groups>();
                    mainGroups = _context.Groups.Where(x => x.IsMainGroup == true).ToList();
                    mainGroups.Insert(0, new Groups() { id = 0, GroupNameAr = "", GroupNameEn = "" });
                    ViewBag.mainGroups = mainGroups;
                    gv.id = g.id;
                    gv.GroupNameAr = g.GroupNameAr;
                    gv.GroupNameEn = g.GroupNameEn;
                    gv.IsMainGroup = g.IsMainGroup;
                    gv.mainGroupId = g.mainGroupId;
                    gv.GroupImgFile = g.GroupImgFile;
                }
               
                return View(gv);
            }
            catch (Exception)
            {
                return View(gv);

            }
           
        }

        // POST: GroupsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GroupsViewModel u)
        {
            try
            {
                string ImageName = "";
                if (u.itemImage != null)
                {
                    string uploads = Path.Combine(hosting.WebRootPath, "GroupImages");
                    ImageName = u.itemImage.FileName;
                    string fullPath = Path.Combine(uploads, ImageName);
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
                var g = _context.Groups.Find(id);
                if (g!=null)
                {
                    g.GroupNameAr = u.GroupNameAr;
                    g.GroupNameEn = u.GroupNameEn;
                    g.IsMainGroup = u.IsMainGroup;
                    g.mainGroupId = u.IsMainGroup == true ? 0 : u.mainGroupId;
                    g.GroupImgFile = ImageName !=""? ImageName: g.GroupImgFile;

                }             
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }       
        public ActionResult Delete(int id)
        {
            try
            {
                var g = _context.Groups.Find(id);
                _context.Groups.Remove(g);
                string ImageName = g.GroupImgFile;
                if (_context.SaveChanges()>0)
                {
                    if (ImageName != null)
                    {
                        string uploads = Path.Combine(hosting.WebRootPath, "GroupImages");                       
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
    }
}
