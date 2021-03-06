using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using comestic.Models;

namespace comestic
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
            services.AddControllersWithViews();

            var serverVersion = new MySqlServerVersion(new Version(10, 4, 21)); // Get the value from SELECT VERSION()
            string connectionString = Configuration.GetConnectionString("server=localhost; username=root;password=01672362745Ngan;database=comestic_csharp;SslMode = none;");
            services.AddDbContext<ShopContext>(c => c.UseMySql("server=localhost; username=root;password=01672362745Ngan;database=comestic_csharp;SslMode = none;", serverVersion));
            // services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ShopContext>();
            // services.AddDbContext<ShopContext>(options => options.UseMySQL("server=localhost; username=root;password=01672362745Ngan;database=comestic_csharp;SslMode = none;"));
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Index}/{id?}");
            });
        }
    }
}
