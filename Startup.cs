using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using comestic_csharp.Models;
using Microsoft.AspNetCore.Http;

namespace comestic_csharp
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie( options => {

                        options.LoginPath = "/Admin/Login/index";
                        options.LogoutPath = "/Admin/Login/signout";
                        options.AccessDeniedPath = "/Admin/accessdenied";

                    });
            
            services.AddMvc();
            services.AddSession();
            services.AddControllersWithViews();

            var serverVersion = new MySqlServerVersion(new Version(10, 4, 21)); // Get the value from SELECT VERSION()
            string connectionString = Configuration.GetConnectionString("server=localhost; username=root;password=01672362745Ngan;database=comestic;SslMode = none;");
            services.AddDbContext<ShopContext>(c => c.UseLazyLoadingProxies().UseMySql("server=localhost; username=root;password=01672362745Ngan;database=comestic;SslMode = none;", serverVersion));
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
