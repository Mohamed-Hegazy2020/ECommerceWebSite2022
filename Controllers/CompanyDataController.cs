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
    public class CompanyDataController : Controller
    {
        private readonly shopingDBContext _context;
        private readonly IHostingEnvironment hosting;

        public CompanyDataController(shopingDBContext context, IHostingEnvironment hosting)
        {
            _context = context;
            this.hosting = hosting;
        }
        // GET: CompanyDataController
        public ActionResult Index()
        {
            CompanyDataViewModel cv = new CompanyDataViewModel();
            try
            {
                var c = _context.CompanyDatas.FirstOrDefault();
                if (c != null)
                {
                    cv.CompanyNameAr = c.CompanyNameAr;
                    cv.CompanyNameEn = c.CompanyNameEn;
                    cv.AddressAr = c.AddressAr;
                    cv.AddressEn = c.AddressEn;
                    cv.Email = c.Email;
                    cv.LogoImage = c.LogoImage;
                    cv.Phone = c.Phone;
                    cv.Mobile = c.Mobile;
                    cv.Fax = c.Fax;
                    cv.FaceBookLink = c.FaceBookLink;
                    cv.TwitterLink = c.TwitterLink;
                    cv.InstgramLink = c.InstgramLink;
                    cv.LinkedinLink = c.LinkedinLink;

                }

                return View(cv);

            }
            catch (Exception)
            {
                return View(cv);

            }
        }

        // GET: CompanyDataController/Create
        public ActionResult Create()
        {
            CompanyDataViewModel cv = new CompanyDataViewModel();
            try
            {
                var c = _context.CompanyDatas.FirstOrDefault();
                if (c != null)
                {
                    cv.CompanyNameAr = c.CompanyNameAr;
                    cv.CompanyNameEn = c.CompanyNameEn;
                    cv.AddressAr = c.AddressAr;
                    cv.AddressEn = c.AddressEn;
                    cv.Email = c.Email;
                    cv.LogoImage = c.LogoImage;
                    cv.Phone = c.Phone;
                    cv.Mobile = c.Mobile;
                    cv.Fax = c.Fax;
                    cv.FaceBookLink = c.FaceBookLink;
                    cv.TwitterLink = c.TwitterLink;
                    cv.InstgramLink = c.InstgramLink;
                    cv.LinkedinLink = c.LinkedinLink;
                    cv.AboutDescreptionAr = c.AboutDescreptionAr;
                    cv.AboutDescreptionEn = c.AboutDescreptionEn;
                    cv.LogoImage = c.LogoImage;
                }
                return View(cv);
            }
            catch (Exception)
            {
                return View(cv);

            }
           
        }

        // POST: CompanyDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyDataViewModel cv)
        {
            try
            {
                using (_context)
                {
                    string ImageName = "";
                    if (cv.itemImage != null)
                    {
                        string uploads = Path.Combine(hosting.WebRootPath, "GroupImages");
                        ImageName = cv.itemImage.FileName;
                        string fullPath = Path.Combine(uploads, ImageName);
                        if (System.IO.File.Exists(fullPath))
                        {
                            //System.IO.File.Delete(fullPath);
                            //cv.itemImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                        }
                        else
                        {
                            cv.itemImage.CopyTo(new FileStream(fullPath, FileMode.Create));
                        }

                    }
                    var comp = _context.CompanyDatas.ToList();
                    if (comp.Count > 0)
                    {
                        comp.First().CompanyNameAr = cv.CompanyNameAr;
                        comp.First().CompanyNameEn = cv.CompanyNameEn;
                        comp.First().AddressAr = cv.AddressAr;
                        comp.First().AddressEn = cv.AddressEn;
                        comp.First().Email = cv.Email;
                        comp.First().Phone = cv.Phone;
                        comp.First().Mobile = cv.Mobile;
                        comp.First().Fax = cv.Fax;
                        comp.First().FaceBookLink = cv.FaceBookLink;
                        comp.First().TwitterLink = cv.TwitterLink;
                        comp.First().InstgramLink = cv.InstgramLink;
                        comp.First().LinkedinLink = cv.LinkedinLink;
                        comp.First().AboutDescreptionAr = cv.AboutDescreptionAr;
                        comp.First().AboutDescreptionEn = cv.AboutDescreptionEn;
                        comp.First().LogoImage = ImageName != "" ? ImageName : comp.First().LogoImage;

                        _context.SaveChanges();
                    }
                    else
                    {
                        CompanyData c = new CompanyData
                        {
                            CompanyNameAr = cv.CompanyNameAr,
                            CompanyNameEn = cv.CompanyNameEn,
                            AddressAr = cv.AddressAr,
                            AddressEn = cv.AddressEn,
                            Email = cv.Email,
                            Phone = cv.Phone,
                            Mobile = cv.Mobile,
                            Fax = cv.Fax,
                            FaceBookLink = cv.FaceBookLink,
                            TwitterLink = cv.TwitterLink,
                            InstgramLink = cv.InstgramLink,
                            LinkedinLink = cv.LinkedinLink,
                            AboutDescreptionAr = cv.AboutDescreptionAr,
                            AboutDescreptionEn = cv.AboutDescreptionEn,
                        LogoImage = ImageName,
                        };
                        _context.CompanyDatas.Add(c);
                        _context.SaveChanges();
                    }


                    return RedirectToAction(nameof(Index));
                }
     
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public JsonResult GetCompanyData()
        {
            CompanyDataViewModel cv = new CompanyDataViewModel();
            try
            {
                var c = _context.CompanyDatas.FirstOrDefault();
                if (c != null)
                {
                    cv.CompanyNameAr = c.CompanyNameAr;
                    cv.CompanyNameEn = c.CompanyNameEn;
                    cv.AddressAr = c.AddressAr;
                    cv.AddressEn = c.AddressEn;
                    cv.Email = c.Email;
                    cv.LogoImage = c.LogoImage;
                    cv.Phone = c.Phone;
                    cv.Mobile = c.Mobile;
                    cv.Fax = c.Fax;
                    cv.FaceBookLink = c.FaceBookLink;
                    cv.TwitterLink = c.TwitterLink;
                    cv.InstgramLink = c.InstgramLink;
                    cv.LinkedinLink = c.LinkedinLink;

                }
                return Json(cv);
            }
            catch (Exception)
            {
                return Json(cv);

            }
            
        }

        [HttpGet]
        public JsonResult getGroups()
        {
            List<GroupsViewModel> g = new List<GroupsViewModel>();
            try
            {
                var gs = _context.Groups.Where(x=>x.IsMainGroup==true).ToList();
                g = gs.Select(x =>
                {
                    GroupsViewModel l = new GroupsViewModel();
                    l.id = x.id;
                    l.GroupNameAr = x.GroupNameAr;
                    l.GroupNameEn = x.GroupNameEn;
                    l.GroupImgFile = x.GroupImgFile;

                    return l;

                }).ToList();
                return Json(g);
            }
            catch (Exception)
            {
                return Json(g);

            }

        }


        
    }
}
