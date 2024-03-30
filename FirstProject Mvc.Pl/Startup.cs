using FirstProject_Mvc.DAL.Data;
using FirstProject_Mvc.PLL.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProject_Mvc.PLL.Repository;
using AspNetCoreHero.ToastNotification;
using FirstProject_Mvc.Pl.Helpersprofile;

namespace FirstProject_Mvc.Pl
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
            // ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            //applicationDbContext.//

            //services.AddScoped<ApplicationDbContext>();
            //services.AddScoped <DbContextOptions<ApplicationDbContext>>();

            services.AddDbContext<ApplicationDbContext>(
                option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionStrings"))

                
                ) ;
            services.AddNotyf(con =>
            {

                con.Position = NotyfPosition.TopRight;
                con.DurationInSeconds = 10;
                con.IsDismissable = true;

			}) ;

            services.AddAutoMapper(M => M.AddProfile(new MappingProfile()));
   //         services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
   //         {
   //             ProgressBar = true,
   //             PositionClass =ToastPositions.TopRight,
   //             CloseButton = true
			//});
            services.AddControllersWithViews();

            services.AddScoped<IdepartmentRepository, DepartmentRepository >();
            services.AddScoped<IEmployeeRepository, EmployeeRepository >();
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
