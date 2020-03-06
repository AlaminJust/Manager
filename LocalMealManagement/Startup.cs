using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalMealManagement.Models;
using LocalMealManagement.Secuirity;
using LocalMealManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LocalMealManagement
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
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>().
                AddEntityFrameworkStores<AppDbContext>();
            services.AddControllersWithViews();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("SuparAdmin", policy =>
                {
                    policy.AddRequirements( new ManageAdminRollAndClaimsRequirement());
                });
            });
            services.AddScoped<IAuthorizationHandler, IsGroupAdmin>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddMvc();
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

       
            app.UseAuthentication();
            app.UseRouting();
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
