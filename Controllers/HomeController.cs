 using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyECommerceWebSite2022.Models;
using MyECommerceWebSite2022.ModelsView;
using MyECommerceWebSite2022.Repositores;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.Controllers
{
    public class HomeController : Controller
    {
        List<Items> itms = new List<Items>();
      
        private readonly ILogger<HomeController> _logger;
        private readonly  shopingDBContext _context;
        static string token = "rLtt6JWvbUHDDhsZnfpAhpYk4dxYDQkbcPTyGaKp2TYqQgG7FGZ5Th_WD53Oq8Ebz6A53njUoo1w3pjU1D4vs_ZMqFiz_j0urb_BH9Oq9VZoKFoJEDAbRZepGcQanImyYrry7Kt6MnMdgfG5jn4HngWoRdKduNNyP4kzcp3mRv7x00ahkm9LAK7ZRieg7k1PDAnBIOG3EyVSJ5kK4WLMvYr7sCwHbHcu4A5WwelxYK0GMJy37bNAarSJDFQsJ2ZvJjvMDmfWwDVFEVe_5tOomfVNt6bOg9mexbGjMrnHBnKnZR1vQbBtQieDlQepzTZMuQrSuKn-t5XZM7V6fCW7oP-uXGX-sMOajeX65JOf6XVpk29DP6ro8WTAflCDANC193yof8-f5_EYY-3hXhJj7RBXmizDpneEQDSaSz5sFk0sV5qPcARJ9zGG73vuGFyenjPPmtDtXtpx35A-BVcOSBYVIWe9kndG3nclfefjKEuZ3m4jL9Gg1h2JBvmXSMYiZtp9MR5I6pvbvylU_PP5xJFSjVTIz7IQSjcVGO41npnwIxRXNRxFOdIUHn0tjQ-7LwvEcTXyPsHXcMD8WtgBh-wxR8aKX7WPSsT1O8d8reb2aR7K3rkV3K82K_0OgawImEpwSvp9MNKynEAJQS6ZHe_J_l77652xwPNxMRTMASk1ZsJL";
        static string baseURL = "https://apitest.myfatoorah.com";
        public HomeController(ILogger<HomeController> logger, shopingDBContext context)
        {
            _logger = logger;
            _context = context;
           
        }

        public IActionResult Index()
        {
            ShowDataViewModel d = new ShowDataViewModel();
            try
            {
                ViewData["lan"] = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
                var company = _context.CompanyDatas.FirstOrDefault();
                var groups = _context.Groups.ToList();
                var itms = _context.Items.ToList();
                if (company!=null)
                {
                    d.CompanyName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en"? company.CompanyNameEn: company.CompanyNameAr;                   
                    d.Address = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? company.AddressEn : company.AddressAr;
                    d.Email = company.Email;
                    d.Fax = company.Fax;
                    d.Mobile = company.Mobile;
                    d.Phone = company.Phone;
                    d.FaceBookLink = company.FaceBookLink;
                    d.InstgramLink = company.InstgramLink;
                    d.LinkedinLink = company.LinkedinLink;
                    d.TwitterLink = company.TwitterLink;
                    d.LogoImage = company.LogoImage;
                    d.Groups = groups;
                    d.Items = itms;

                }
                return View(d);
            }
            catch (Exception)
            {

                return View(d);
            }
            
        }
        public IActionResult Index2()
        {          
            ShowDataViewModel d = new ShowDataViewModel();
            try
            {
                ViewData["lan"] = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
                var company = _context.CompanyDatas.FirstOrDefault();
                var groups = _context.Groups.ToList();
                var itms = _context.Items.ToList();
                if (company != null)
                {
                    d.CompanyName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? company.CompanyNameEn : company.CompanyNameAr;
                    d.Address = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? company.AddressEn : company.AddressAr;
                    d.Email = company.Email;
                    d.Fax = company.Fax;
                    d.Mobile = company.Mobile;
                    d.Phone = company.Phone;
                    d.FaceBookLink = company.FaceBookLink;
                    d.InstgramLink = company.InstgramLink;
                    d.LinkedinLink = company.LinkedinLink;
                    d.TwitterLink = company.TwitterLink;
                    d.LogoImage = company.LogoImage;
                    d.Groups = groups;
                    d.Items = itms;

                }
                return View(d);
            }
            catch (Exception)
            {

                return View(d);
            }

        }

        [HttpPost]
        public JsonResult getItems(int gid)
        {
            List<Items> itms = new List<Items>();
            try
            {
                if (gid == 0)
                {
                   itms = _context.Items.ToList();
                    
                }
                else
                {
                    itms = _context.Items.Where(x => x.groupId == gid).ToList();
         
                }

                return Json(itms);
            }
            catch (Exception)
            {
                return Json(itms);
            }
        }


        public async Task<string> InitiatePayment()
        {
            var intiatePaymentRequest = new
            {
                InvoiceAmount = 100,
                CurrencyIso = "kwd"
            };

            var intitateRequestJSON = JsonConvert.SerializeObject(intiatePaymentRequest);
            return await PerformRequest(intitateRequestJSON, "InitiatePayment").ConfigureAwait(false);

        }

        public async Task<string> ExecutePayment(int PaymentMethodId, decimal InvoiceValue)
        {
            //var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();         
            //var culture = rqf.RequestCulture.Culture;
            var executePaymentRequest = new
            {
                //required fields
                PaymentMethodId = PaymentMethodId,
                InvoiceValue = InvoiceValue,
                CallBackUrl = "https://example.com/callback",
                ErrorUrl = "https://example.com/error",
                //optional fields 
                CustomerName = "Customer Name",
                DisplayCurrencyIso = "EGP",
                MobileCountryCode = "20",
                CustomerMobile = "12345678",
                CustomerEmail = "email@example.com",
                Language = "ar",
                CustomerReference = "",
                CustomerCivilId = "",
                UserDefinedField = "",
                ExpiryDate = DateTime.Now.AddYears(1),

            };
            var executeRequestJSON = JsonConvert.SerializeObject(executePaymentRequest);
            return await PerformRequest(executeRequestJSON, "ExecutePayment").ConfigureAwait(false);
        }

        public async Task<string> PerformRequest(string requestJSON, string endPoint)
        {

            string url = baseURL + $"/v2/{endPoint}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var httpContent = new StringContent(requestJSON, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(url, httpContent).ConfigureAwait(false);
            string response = string.Empty;
            if (!responseMessage.IsSuccessStatusCode)
            {
                response = JsonConvert.SerializeObject(new
                {
                    IsSuccess = false,
                    Message = responseMessage.StatusCode.ToString()
                });
            }
            else
            {
                response = await responseMessage.Content.ReadAsStringAsync();
            }
            return response;


        }

        [HttpPost]
        public async Task<JsonResult> payming(InvoiceMasterViewModel InvoiceMaster, List<InvoiceDetailsViewModel> InvoiceDetailes, decimal amount, int PaymentmethodType)
        {
            try
            {
                if (PaymentmethodType!=100)
                {
                    int InvoiceId = 0;
                    JObject json = null;
                    JToken jsonData = null;
                    JToken jsonurl = null;
                    string url = "";

                    JObject getPaymentStatusResponsejson = null;
                    JToken getPaymentStatusResponsejsonData = null;
                    //JToken jsonurl = null;
                    string InvoiceStatus = "";

                    var executeResponse = await ExecutePayment(PaymentmethodType, amount).ConfigureAwait(false);
                    if (executeResponse!=null)
                    {
                        json = JObject.Parse(executeResponse);
                    }
                    if (json!=null)
                    {
                        jsonData = json["Data"];
                    }
                    if (jsonData != null)
                    {
                        jsonurl = jsonData["PaymentURL"];
                    }
                    if (jsonurl != null)
                    {
                        url = jsonurl.ToString();
                        InvoiceId=Convert.ToInt32(jsonData["InvoiceId"]);
                    }                    
                    if (url != null && url != "")
                    {
                        using (var t = _context.Database.BeginTransaction())
                        {
                            if (InvoiceMaster != null && InvoiceDetailes.Count > 0)
                            {
                                string key = (InvoiceId).ToString();
                                string keyType = "InvoiceId";//or it can be PaymentId
                                var getPaymentStatusResponse = await GetPaymentStatus(key, keyType).ConfigureAwait(false);
                                if (getPaymentStatusResponse != null)
                                {
                                    getPaymentStatusResponsejson = JObject.Parse(getPaymentStatusResponse);
                                }
                                if (getPaymentStatusResponsejson != null)
                                {
                                    getPaymentStatusResponsejsonData = getPaymentStatusResponsejson["Data"];
                                }
                                if (getPaymentStatusResponsejsonData != null)
                                {
                                    InvoiceStatus = getPaymentStatusResponsejsonData["InvoiceStatus"].ToString();
                                }

                                InvoiceMaster m = new InvoiceMaster();
                                m.customerName = InvoiceMaster.customerName;
                                m.customerTel = InvoiceMaster.customerTel;
                                m.customerMobile = InvoiceMaster.customerMobile;
                                m.customerAddress = InvoiceMaster.customerAddress;
                                m.deleverMethod = InvoiceMaster.deleverMethod;
                                m.invoiceDate = DateTime.Now;
                                m.IsDeleverd = false;
                                m.IsPayed = InvoiceStatus== "Paid" ? true:false;
                                m.paymentMethod = PaymentmethodType;
                                m.PaymentURL = url;
                                m.InvoiceId = InvoiceId;
                                m.InvoiceStatus = InvoiceStatus;
                                m.InvoiceTotal = amount;
                                _context.InvoiceMaster.Add(m);
                                _context.SaveChanges();

                                foreach (var item in InvoiceDetailes)
                                {
                                    InvoiceDetailes d = new InvoiceDetailes();
                                    d.masterId = m.id;
                                    d.itemName = item.itemName;
                                    d.itemCode = item.itemCode;
                                    d.price = item.price;
                                    d.quantity = item.quantity;
                                    d.IsViewed = false;
                                    d.invNo = m.id;
                                    _context.InvoiceDetailes.Add(d);
                                    _context.SaveChanges();
                                }
                                _context.SaveChanges();
                                t.Commit();
                                HttpContext.Session.Clear();

                            }

                        }
                        
                        return Json(new { url = url,msg="payed" });
                    }
                    else
                    {
                        return Json(new { url = "فشلت عملية الدفع", msg = "f" });

                    }
                }
                else
                {
                    using (var t = _context.Database.BeginTransaction())
                    {
                        if (InvoiceMaster != null && InvoiceDetailes.Count > 0)
                        {
                            InvoiceMaster m = new InvoiceMaster();
                            m.customerName = InvoiceMaster.customerName;
                            m.customerTel = InvoiceMaster.customerTel;
                            m.customerMobile = InvoiceMaster.customerMobile;
                            m.customerAddress = InvoiceMaster.customerAddress;
                            m.deleverMethod = InvoiceMaster.deleverMethod;
                            m.invoiceDate = DateTime.Now;
                            m.IsDeleverd = false;
                            m.IsPayed = false;
                            m.paymentMethod = PaymentmethodType;
                            m.InvoiceTotal = amount;
                            _context.InvoiceMaster.Add(m);
                            _context.SaveChanges();

                            foreach (var item in InvoiceDetailes)
                            {
                                InvoiceDetailes d = new InvoiceDetailes();
                                d.masterId = m.id;
                                d.itemName = item.itemName;
                                d.itemCode = item.itemCode;
                                d.price = item.price;
                                d.quantity = item.quantity;
                                d.IsViewed = false;
                                d.invNo = m.id;
                                _context.InvoiceDetailes.Add(d);
                                _context.SaveChanges();
                            }
                            _context.SaveChanges();
                            t.Commit();
                            HttpContext.Session.Clear();
                        }

                    }
                   
                    return Json(new { url = "تم تنفيذ طلبك بنجاح", msg = "saved" });
                }
             
            }
            catch (Exception ex)
            {
                return Json(new { url = ex.Message, msg = "f" });

            }


        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AdminPanel()
        {
            AdminPanelViewModel p = new AdminPanelViewModel();
            try
            {
                var orders = _context.InvoiceMaster.ToList();
                var customers = orders.GroupBy(x=>x.customerName).ToList();

                List<ItemsViewModel> Items = new List<ItemsViewModel>();
                List<customersViewModel> custs = new List<customersViewModel>();
                var gs = _context.Items.ToList();
                Items = gs.Select(x =>
                {
                    ItemsViewModel l = new ItemsViewModel();
                    l.id = x.id;
                    l.itemNameAr = x.itemNameAr;
                    l.itemNameEn = x.itemNameEn;
                    l.itemDescreptionAr = x.itemDescreptionAr;
                    l.itemDescreptionEn = x.itemDescreptionEn;
                    l.quantity = x.quantity;                   
                    l.price = x.price;
                    l.itemImgFile = x.itemImgFile;

                    var unt = _context.Units.Find(x.unitId);
                    if (unt != null)
                    {
                        l.unitName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? unt.UnitNameEn : unt.UnitNameAr;
                    }
                    var grop = _context.Groups.Find(x.groupId);
                    if (grop != null)
                    {
                        l.groupName = System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? grop.GroupNameEn : grop.GroupNameAr;

                    }

                    return l;

                }).ToList();

                custs = customers.Select(x =>
                {
                    customersViewModel l = new customersViewModel();                  
                    l.customerName = x.FirstOrDefault().customerName;
                    l.customerAddress = x.FirstOrDefault().customerAddress;
                    l.customerMobile = x.FirstOrDefault().customerMobile;
                    l.customerTel = x.FirstOrDefault().customerTel;   
                    return l;

                }).ToList();


                p.allOrders = orders.Count;
                p.donOrders = orders.Where(x => x.IsDeleverd == true).Count();
                p.notDonOrders = orders.Where(x => x.IsDeleverd != true).Count();
                p.newOrders = orders.Where(x => x.IsDeleverd != true).Count();
                p.finshedItems = gs.Where(x => x.quantity <= 0).Count();
                p.paidOrders = orders.Where(x => x.IsPayed == true).Count();
                p.notPaidOrders = orders.Where(x => x.IsPayed != true).Count();
                p.ItemsViewModel = Items;
                p.customersViewModel = custs;

                return View(p);
            }
            catch (Exception ex)
            {

                return View(p);
            }
           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
        [HttpPost]
        public JsonResult addItemToCard(int id,int shopingCar)
        {
            List<Items> olditms = new List<Items>();
            var newitm = _context.Items.Where(x => x.id == id).FirstOrDefault();
            newitm.quantity = 1;
            olditms = HttpContext.Session.GetComplexData<List<Items>>("cardItems");
            if (olditms == null)
            {
                List<Items> olditms2 = new List<Items>();
                olditms2.Add(newitm);
                HttpContext.Session.SetComplexData("cardItems", olditms2);
            }
            else
            {
                var isExist = olditms.Where(x => x.id == id).FirstOrDefault();
                if (isExist == null)
                {
                    olditms.Add(newitm);
                }
                else
                {
                    olditms.Where(x => x.id == id).FirstOrDefault().quantity+=1;
                }
               
                HttpContext.Session.SetComplexData("cardItems", olditms);
            }
            HttpContext.Session.SetShopingCarCount("shopingCarCount", HttpContext.Session.GetComplexData<List<Items>>("cardItems").Count);
            return Json(HttpContext.Session.GetShopingCarCount("shopingCarCount"));
        }

        [HttpPost]
        public JsonResult DeleteItemFromCard(int id, int shopingCar)
        {
            List<Items> olditms = new List<Items>();
            var newitm = _context.Items.Where(x => x.id == id).FirstOrDefault();
            olditms = HttpContext.Session.GetComplexData<List<Items>>("cardItems");
            if (olditms != null)
            {
                olditms = olditms.Where(x => x.id != id).ToList();
                //olditms.Remove(newitm);
                HttpContext.Session.SetComplexData("cardItems", olditms);
            }
            HttpContext.Session.SetShopingCarCount("shopingCarCount", HttpContext.Session.GetComplexData<List<Items>>("cardItems").Count);
            return Json(true);
        }

        [HttpGet]
        public JsonResult ShowItemCard()
        {     
            return Json(HttpContext.Session.GetComplexData<List<Items>>("cardItems"));
        }
        [HttpGet]
        public JsonResult GeSshopingCarCount()
        {
            try
            {
                //var dc = _context.Curunces.Where(x=>x.isDefualtCuruncy==true).FirstOrDefault();
                return Json(HttpContext.Session.GetShopingCarCount("shopingCarCount"));
            }
            catch (Exception)
            {
                return Json(0);
            }
            
        }
        [HttpGet]
        public JsonResult GetDefultCuruncy()
        {
            try
            {
                var dc = _context.Curunces.Where(x=>x.isDefualtCuruncy==true).FirstOrDefault();
                return Json(dc !=null? (System.Threading.Thread.CurrentThread.CurrentCulture.Name == "en" ? dc.CuruncyNameEn:dc.CuruncyNameAr) :"");
            }
            catch (Exception)
            {
                return Json("");
            }
            
        }
        [HttpPost]
        public JsonResult changeItemCardQty(int id, decimal qty)
        {
            List<Items> olditms = new List<Items>();           
            olditms = HttpContext.Session.GetComplexData<List<Items>>("cardItems");
            if (olditms == null)
            {
               
            }
            else
            {
                var isExist = olditms.Where(x => x.id == id).FirstOrDefault();
                if (isExist != null)
                {
                    olditms.Where(x => x.id == id).FirstOrDefault().quantity = qty;
                }        

                HttpContext.Session.SetComplexData("cardItems", olditms);
            }
           
            return Json(true);
        }

        public static async Task<string> GetPaymentStatus(string key, string keyType)
        {
            var GetPaymentStatusRequest = new
            {
                Key = key,
                KeyType = keyType
            };

            var GetPaymentStatusRequestJSON = JsonConvert.SerializeObject(GetPaymentStatusRequest);
            return await PerformRequestGetPaymentStatus(GetPaymentStatusRequestJSON, "GetPaymentStatus").ConfigureAwait(false);

        }
        public static async Task<string> PerformRequestGetPaymentStatus(string requestJSON, string endPoint)
        {
            string url = baseURL + $"/v2/{endPoint}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var httpContent = new StringContent(requestJSON, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(url, httpContent).ConfigureAwait(false);
            string response = string.Empty;
            if (!responseMessage.IsSuccessStatusCode)
            {
                response = JsonConvert.SerializeObject(new
                {
                    IsSuccess = false,
                    Message = responseMessage.StatusCode.ToString()
                });
            }
            else
            {
                response = await responseMessage.Content.ReadAsStringAsync();
            }

            return response;
        }



        [HttpGet]
        public JsonResult getSalesOverMonthes()
        {
            List<SalesOverMonthesViewModel> SalesOverMonthesViewModel = new List<SalesOverMonthesViewModel>();
            try
            {
                var invs = (from m in _context.InvoiceMaster
                            select new { m.invoiceDate, m.InvoiceTotal }
                            ).ToList();
                for (int i = 1; i <= 12; i++)
                {
                    SalesOverMonthesViewModel.Add(new SalesOverMonthesViewModel() {monthName=new DateTime(2020,i,1).ToString("MMMM"),amount= invs.Where(x=>x.invoiceDate.Month==i).Sum(s=>s.InvoiceTotal) });

                }

            }
            catch (Exception)
            {

               
            }
            return Json(SalesOverMonthesViewModel);
        }



        [HttpGet]
        public JsonResult getSalesOverYears()
        {
            List<SalesOverMonthesViewModel> SalesOverMonthesViewModel = new List<SalesOverMonthesViewModel>();
            try
            {
                var invs = (from m in _context.InvoiceMaster
                            select new { m.invoiceDate, m.InvoiceTotal }
                            ).ToList();


                SalesOverMonthesViewModel = invs.GroupBy(g => g.invoiceDate.Year).Select(x =>
                {
                    SalesOverMonthesViewModel l = new SalesOverMonthesViewModel();
                    l.monthName = x.FirstOrDefault().invoiceDate.Year.ToString();
                    l.amount = x.Sum(a => a.InvoiceTotal);
                    return l;
                }).ToList();

            }
            catch (Exception)
            {


            }
            return Json(SalesOverMonthesViewModel);
        }


        [HttpGet]
        public JsonResult getProductsSales()
        {
            List<SalesOverMonthesViewModel> SalesOverMonthesViewModel = new List<SalesOverMonthesViewModel>();
            try
            {
                var invs = (from m in _context.InvoiceDetailes 
                            select new { m.itemName, m.quantity,m.price,m.itemCode }
                            ).ToList();


                SalesOverMonthesViewModel = invs.GroupBy(g => g.itemCode).Select(x =>
                {
                    SalesOverMonthesViewModel l = new SalesOverMonthesViewModel();
                    l.monthName = x.FirstOrDefault().itemName.ToString();
                    l.amount = x.Sum(a => a.quantity*a.price);
                    return l;
                }).ToList();

            }
            catch (Exception)
            {


            }
            return Json(SalesOverMonthesViewModel);
        }

    }
}
