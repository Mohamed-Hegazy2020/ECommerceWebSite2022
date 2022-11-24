using DinkToPdf;
using DinkToPdf.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.Repositores
{
    public class ExportToPdf
    {
        private readonly IConverter _converter;
        public ExportToPdf(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GeneratePdfReport(string s )
        {
            var html = s;
           
            GlobalSettings globalSettings = new GlobalSettings();
            globalSettings.ColorMode = ColorMode.Color;
            globalSettings.Orientation = Orientation.Portrait;
            globalSettings.PaperSize = PaperKind.A4;
            globalSettings.Margins = new MarginSettings { Top = 25, Bottom = 25 };
            ObjectSettings objectSettings = new ObjectSettings();
            objectSettings.PagesCount = true;
            objectSettings.HtmlContent = html;                   
            WebSettings webSettings = new WebSettings();
            webSettings.DefaultEncoding = "utf-8";
            webSettings.LoadImages = true;
            //webSettings.UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "UserAssets/css/", "bootstrap.min.css");
           //HeaderSettings headerSettings = new HeaderSettings()
           // {
           //     FontSize = 12,
           //     Left = "Name",
           //     Right = $"<img src='@Url.Content('~/assets/images/w1.png')' />",
           //     Line = true,
           //     Spacing = 2.812
           // };
            
            //headerSettings.HtmUrl= "https://www.google.com/";


            //headerSettings.FontSize = 15;
            //headerSettings.FontName = "Ariel";
            //headerSettings.Right = "Page [page] of [toPage]";
            //headerSettings.Line = true;
            FooterSettings footerSettings = new FooterSettings();
            footerSettings.FontSize = 12;
            footerSettings.FontName = "Ariel";
            //footerSettings.Center = "This is for demonstration purposes only.";
            footerSettings.Right = "توقيع المستلم/.................................";
            footerSettings.Left = DateTime.Now.ToString();
            footerSettings.Line = true;
            //objectSettings.HeaderSettings = headerSettings;
            objectSettings.FooterSettings = footerSettings;
            objectSettings.WebSettings = webSettings;
            HtmlToPdfDocument htmlToPdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings },
            };
            return _converter.Convert(htmlToPdfDocument);
        }
    }
}
