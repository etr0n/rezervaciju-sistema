using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using GrozioSalonuISCF.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GrozioSalonuISCF.Areas.Identity;
using GrozioSalonuISCF.Areas.Identity.Data;
using System.Globalization;


namespace GrozioSalonuISCF
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddRazorPages();
            services.AddDefaultIdentity<GrozioSalonuISCFUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IServiceProvider services)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
                endpoints.MapRazorPages();
            });

            CreateUserRoles(services).Wait();
          

        }
        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<GrozioSalonuISCFUser>>();

            IdentityResult roleResult;
            //Adding Addmin Role    
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                //create the roles and seed them to the database    
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            roleCheck = await RoleManager.RoleExistsAsync("Salono Admin");
            if (!roleCheck)
            {
                //create the roles and seed them to the database    
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Salono Admin"));
            }

            roleCheck = await RoleManager.RoleExistsAsync("Klientas");
            if (!roleCheck)
            {
                //create the roles and seed them to the database    
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Klientas"));
            }

            //Assign Admin role to the main User here we have given our newly loregistered login id for Admin management    
            GrozioSalonuISCFUser user = await UserManager.FindByEmailAsync("admin@gmail.com");
            var User = new GrozioSalonuISCFUser();
            await UserManager.AddToRoleAsync(user, "Admin");

            user = await UserManager.FindByEmailAsync("salonoadmin@gmail.com");
            await UserManager.AddToRoleAsync(user, "Salono Admin");

            user = await UserManager.FindByEmailAsync("norte@gmail.com");
            await UserManager.AddToRoleAsync(user, "Klientas");

            user = await UserManager.FindByEmailAsync("ieva@gmail.com");
            await UserManager.AddToRoleAsync(user, "Klientas");

        }
    }
}
