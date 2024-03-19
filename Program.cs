using Microsoft.EntityFrameworkCore;
using WarehouseManager.Data;

namespace WarehouseManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // ...

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDevOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:4200") // Replace with the actual port Angular is running on
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            // ...
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ...

            app.UseCors("AllowAngularDevOrigin"); // Make sure this is before UseEndpoints

            // ...
        }

    }
}
