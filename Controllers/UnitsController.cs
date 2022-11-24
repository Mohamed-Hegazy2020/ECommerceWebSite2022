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
    public class UnitsController : Controller
    {
        private readonly shopingDBContext _context;
      
        public UnitsController(shopingDBContext context)
        {
            _context = context;
          
        }
        // GET: UnitsController
        public ActionResult Index()
        {
            List<UnitsViewModel> g = new List<UnitsViewModel>();
            try
            {
                var gs = _context.Units.ToList();
                g = gs.Select(x =>
                {
                    UnitsViewModel l = new UnitsViewModel();
                    l.id = x.id;
                    l.UnitNameAr = x.UnitNameAr;
                    l.UnitNameEn = x.UnitNameEn;                   
                    return l;

                }).ToList();
                return View(g);

            }
            catch (Exception)
            {
                return View(g);

            }
        }

        // GET: UnitsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnitsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnitsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UnitsViewModel u)
        {
            try
            {             

                Units unt = new Units
                {
                    //id = u.id,
                    UnitNameAr = u.UnitNameAr,
                    UnitNameEn = u.UnitNameEn,
                  
                };
                _context.Units.Add(unt);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UnitsController/Edit/5
        public ActionResult Edit(int id)
        {
            var gv = new UnitsViewModel();
            try
            {

                var g = _context.Units.Find(id);
                if (g != null)
                {
                    gv.id = g.id;
                    gv.UnitNameAr = g.UnitNameAr;
                    gv.UnitNameEn = g.UnitNameEn;                   
                }

                return View(gv);
            }
            catch (Exception)
            {
                return View(gv);

            }
        }

        // POST: UnitsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UnitsViewModel u)
        {
            try
            {              
               
                var g = _context.Units.Find(id);
                if (g != null)
                {
                    g.UnitNameAr = u.UnitNameAr;
                    g.UnitNameEn = u.UnitNameEn;                   

                }
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UnitsController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var g = _context.Units.Find(id);
                _context.Units.Remove(g);
                _context.SaveChanges();
                      
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: UnitsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
