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
    public class CuruncesController : Controller
    {
        private readonly shopingDBContext _context;

        public CuruncesController(shopingDBContext context)
        {
            _context = context;

        }
        // GET: CuruncesController
        public ActionResult Index()
        {
            List<CuruncesViewModel> g = new List<CuruncesViewModel>();
            try
            {
                var gs = _context.Curunces.ToList();
                g = gs.Select(x =>
                {
                    CuruncesViewModel l = new CuruncesViewModel();
                    l.id = x.id;
                    l.CuruncyNameAr = x.CuruncyNameAr;
                    l.CuruncyNameEn = x.CuruncyNameEn;
                    l.isDefualtCuruncy = x.isDefualtCuruncy;
                    return l;

                }).ToList();
                return View(g);

            }
            catch (Exception)
            {
                return View(g);

            }
        }

        // GET: CuruncesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CuruncesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CuruncesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CuruncesViewModel u)
        {
            try
            {
                Curunces unt = new Curunces
                {
                    //id = u.id,
                    CuruncyNameAr = u.CuruncyNameAr,
                    CuruncyNameEn = u.CuruncyNameEn,
                    isDefualtCuruncy = u.isDefualtCuruncy

                };
                if (unt.isDefualtCuruncy == true)
                {
                    var oldunt = _context.Curunces.Where(x => x.isDefualtCuruncy == true).FirstOrDefault();
                    if (oldunt != null)
                    {
                        oldunt.isDefualtCuruncy = false;

                    }

                }
                _context.Curunces.Add(unt);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CuruncesController/Edit/5
        public ActionResult Edit(int id)
        {
            var gv = new CuruncesViewModel();
            try
            {

                var g = _context.Curunces.Find(id);
                if (g != null)
                {
                    gv.id = g.id;
                    gv.CuruncyNameAr = g.CuruncyNameAr;
                    gv.CuruncyNameEn = g.CuruncyNameEn;
                    gv.isDefualtCuruncy = g.isDefualtCuruncy;
                }

                return View(gv);
            }
            catch (Exception)
            {
                return View(gv);

            }
        }

        // POST: CuruncesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CuruncesViewModel u)
        {
            try
            {

                var g = _context.Curunces.Find(id);
                if (g != null)
                {
                    g.CuruncyNameAr = u.CuruncyNameAr;
                    g.CuruncyNameEn = u.CuruncyNameEn;
                    g.isDefualtCuruncy = u.isDefualtCuruncy;
                }
                if (u.isDefualtCuruncy == true)
                {
                    var oldunt = _context.Curunces.Where(x => x.isDefualtCuruncy == true && x.id!=g.id).FirstOrDefault();
                    if (oldunt != null)
                    {
                        oldunt.isDefualtCuruncy = false;

                    }

                }
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CuruncesController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var g = _context.Curunces.Find(id);
                _context.Curunces.Remove(g);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
