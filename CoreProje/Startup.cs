using CoreProje.Areas.Writer.Models;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProje
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
    
            services.AddDbContext<Context>();
            services.AddControllersWithViews();     
            services.AddIdentity<WriterUser,WriterRole>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
            /* Authorize iþlemleri proje seviyesinde */
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }); 
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly=true;
                options.ExpireTimeSpan=TimeSpan.FromMinutes(15);
                options.AccessDeniedPath="/ErrorPage/Index/";
                options.LoginPath="/Writer/Login/Index/";
            });
            /*Authorize iþlemleri  bitiþ*/
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //Error Sayfasý ayarlar Baþlangýc
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Page404/");
            // Error Sayfasý ayarlar bitiþ
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //Authentication'un çalýþmasý için kullanýlýr.
            app.UseAuthentication();
            //------------
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
                );
            });

        }
    }
}
