using MyECommerceWebSite2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.ModelsView
{
    public class ShowDataViewModel
    {
        public string CompanyName { get; set; }       
        public string Address { get; set; }       
        public string Email { get; set; }
        public string LogoImage { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string FaceBookLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstgramLink { get; set; }
        public string LinkedinLink { get; set; }
        public List<Groups> Groups { get; set; }
        public List<Items> Items { get; set; }
    }
}
