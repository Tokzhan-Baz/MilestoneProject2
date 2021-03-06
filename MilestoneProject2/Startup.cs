using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MilestoneProject2.Data;
using MilestoneProject2.Models.Identity;


namespace MilestoneProject2
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("ConnectionName"));
            });
           
            services.AddMvc();

            /* services.AddScoped<CompanyService>();
             services.AddScoped<ICompanyRepository, CompanyRepository>();*/

    

            services.AddIdentity<UserEntity, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddMvc(option => option.EnableEndpointRouting = false);

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
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "account",
                    template: "{controller=Account}/{action=Login}/{id?}");
                routes.MapRoute(
                     name: "roles",
                     template: "{controller=Roles}/{action=Index}/{id?}");
                routes.MapRoute(
                     name: "users",
                     template: "{controller=Users}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "News",
                    template: "{controller=News}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "Projects",
                    template: "{controller=Projects}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "Startups",
                    template: "{controller=Startups}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "StartupsNews",
                    template: "{controller=StartupsNews}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "Investors",
                    template: "{controller=Investors}/{action=Index}/{id?}");
            });
        }


    }
}