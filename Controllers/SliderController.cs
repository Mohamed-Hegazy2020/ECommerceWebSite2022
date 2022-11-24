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
    public class SliderController : Controller
    {
        private readonly shopingDBContext _context;
        private readonly IHostingEnvironment hosting;
        public SliderController(shopingDBContext context, IHostingEnvironment hosting)
        {
            _context = context;
            this.hosting = hosting;
        }
        // GET: SliderController
        public ActionResult Index()
        {
            List<SliderViewModel> sv = new List<SliderViewModel>();
            try
            {
                var s = _context.Slider.ToList();
                sv = s.Select(x =>
                {
                    SliderViewModel l = new SliderViewModel();
                    l.id = x.id;
                    l.HedarAr = x.HedarAr;
                    l.HedarEn = x.HedarEn;
                    l.DescreptionAr = x.DescreptionAr;
                    l.DescreptionEn = x.DescreptionEn;
                    l.ImagePath = x.ImagePath;
                    return l;

                }).ToList();
                return View(sv);

            }
            catch (Exception)
            {
                return View(sv);

            }
        }

        // GET: SliderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SliderViewModel s)
        {
            try
            {
                string ImageName = "";
                if (s.SliderImage != null)
                {
                    string uploads = Path.Combine(hosting.WebRootPath, "SliderImages");
                    ImageName = s.SliderImage.FileName;
                    string fullPath = Path.Combine(uploads, ImageName);
                    if (System.IO.File.Exists(fullPath))
                    {
                        //System.IO.File.Delete(fullPath);
                        //u.itemImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }
                    else
                    {
                        s.SliderImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }

                }
                Slider ns = new Slider();
                ns.HedarAr = s.HedarAr;
                ns.HedarEn = s.HedarEn;
                ns.DescreptionAr = s.DescreptionAr;
                ns.DescreptionEn = s.DescreptionEn;               
                ns.ImagePath = ImageName;
                
                _context.Slider.Add(ns);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SliderController/Edit/5
        public ActionResult Edit(int id)
        {
            var gv = new SliderViewModel();
            try
            {

                var g = _context.Slider.Find(id);
                if (g != null)
                {
                    gv.id = g.id;
                    gv.HedarAr = g.HedarAr;
                    gv.HedarEn = g.HedarEn;
                    gv.DescreptionAr = g.DescreptionAr;
                    gv.DescreptionEn = g.DescreptionEn;
                    gv.ImagePath = g.ImagePath;
                }

                return View(gv);
            }
            catch (Exception)
            {
                return View(gv);

            }
        }

        // POST: SliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SliderViewModel u)
        {
            try
            {
                string ImageName = "";
                if (u.SliderImage != null)
                {
                    string uploads = Path.Combine(hosting.WebRootPath, "SliderImages");
                    ImageName = u.SliderImage.FileName;
                    string fullPath = Path.Combine(uploads, ImageName);
                    if (System.IO.File.Exists(fullPath))
                    {
                        //System.IO.File.Delete(fullPath);
                        //u.SliderImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }
                    else
                    {
                        u.SliderImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }

                }
                var g = _context.Slider.Find(id);
                if (g != null)
                {
                    g.HedarAr = u.HedarAr;
                    g.HedarEn = u.HedarEn;
                    g.DescreptionAr = u.DescreptionAr;
                    g.DescreptionEn = u.DescreptionEn;
                    g.ImagePath = ImageName != "" ? ImageName : g.ImagePath;

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
                var g = _context.Slider.Find(id);
                _context.Slider.Remove(g);
                string ImageName = g.ImagePath;
                if (_context.SaveChanges() > 0)
                {
                    if (ImageName != null)
                    {
                        string uploads = Path.Combine(hosting.WebRootPath, "SliderImages");
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
