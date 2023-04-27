using ECommerceMVC.Context;
using ECommerceMVC.Repository;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace ECommerceMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Db Connection 1
            //builder.Services.AddDbContext<EcommerceDbContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
            //);
            // Db Connection 2
            builder.Services.AddDbContext<EcommerceDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("remote"))
            );


            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);

            });


            // Register
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}