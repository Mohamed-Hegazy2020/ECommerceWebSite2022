using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyECommerceWebSite2022.Models
{
    public class shopingDBContext : DbContext
    {
        public shopingDBContext(DbContextOptions<shopingDBContext> options) : base(options)
        {

        }
        public DbSet<CompanyData> CompanyDatas { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<Curunces> Curunces { get; set; }
        public DbSet<InvoiceMaster> InvoiceMaster { get; set; }
        public DbSet<InvoiceDetailes> InvoiceDetailes { get; set; }
        public DbSet<Slider> Slider { get; set; }
    }
}
