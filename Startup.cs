using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MyECommerceWebSite2022.Models;
using MyECommerceWebSite2022.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MyECommerceWebSite2022.Repositores;

using DinkToPdf;
using DinkToPdf.Contracts;
 

namespace MyECommerceWebSite2022
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<shopingDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection"))
            );
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
              .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
              .AddDataAnnotationsLocalization(options =>
              {
                  options.DataAnnotationLocalizerProvider = (type, factory) =>
                  {
                      var assemblyName = new AssemblyName(typeof(SharedResources).GetTypeInfo().Assembly.FullName);
                      return factory.Create("SharedResources", assemblyName.Name);
                  };

              });
            services.AddMvc(options =>
            {
                options.ModelBinderProviders.Insert(0, new InvariantDecimalModelBinderProvider());
            });
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {                 
                  new CultureInfo("ar"),
                  new CultureInfo("en"),
                };
                supportedCultures[0].NumberFormat.NumberDecimalSeparator = ".";
                supportedCultures[1].NumberFormat.NumberDecimalSeparator = ".";
                options.DefaultRequestCulture = new RequestCulture("ar");           
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddSingleton<LocalizationService>();
            services.AddControllersWithViews();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddSingleton<ExportToPdf>();

             services.AddControllersWithViews();
            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            var requestlocalizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(requestlocalizationOptions.Value);
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Index}/{id?}/{id2?}");
                endpoints.MapHub<notfyHub>("/notfyHub");
            });

          
        }
    }
}
