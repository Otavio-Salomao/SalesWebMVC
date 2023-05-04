using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Internal;

namespace SalesWebMVC
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllersWithViews();
            services.AddDbContext<SalesWebMVCContext>(
     options => options.UseSqlServer(Configuration.GetConnectionString("SalesWebMVCContext")));



        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
              
                app.UseHsts();
            }

                app.UseHttpsRedirection();
                app.UseStaticFiles();
                
                app.UseRouting();

                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }


    }
}
