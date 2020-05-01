using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using _9jaTips.Data;
using _9jaTips.Entities;
using _9jaTips.Services.Interfaces;
using _9jaTips.Services.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _9jaTips.Web
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
            services.AddScoped<IFixtures, FixturesRepository>();
            services.AddDbContext<AppDbContext>(
                //option => option.UseSqlServer(Configuration.GetConnectionString("9jaTipsDB")
                options => options.UseSqlServer(Configuration.GetConnectionString("9jaTipsDB"), b => b.MigrationsAssembly("9jaTips.Data")
                ));


            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddControllersWithViews();

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "1057133403225-psvcpdnfeai59oqffr9g75avkc8vmeoj.apps.googleusercontent.com";
                    options.ClientSecret = "U58gCY_7uB0g0NWaxrThgj94";
                })
                .AddFacebook(options =>
                {
                    options.AppId = "550397005869639";
                    options.AppSecret = "02ab78daad2d9fc9466e5c648cdf00c8";
                });

            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddAuthorization();
            
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
