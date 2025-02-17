using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Blogpage.Models;

namespace BasicBlog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Automatically call the CreateHostBuilder and run it
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices(services =>
                    {
                        // Register the BlogContext with SQL Server
                        services.AddDbContext<BlogContext>(options =>
                            options.UseSqlServer("Server=DESKTOP-1OR4C9B\\SQLEXPRESS;Database=BlogDB;Trusted_Connection=True;TrustServerCertificate=true;"));
                        services.AddControllersWithViews();  // Add MVC support
                    });

                    webBuilder.Configure((context, app) =>
                    {
                        // Configure the request pipeline
                        if (context.HostingEnvironment.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();  // Show detailed errors in development
                        }
                        else
                        {
                            app.UseExceptionHandler("/Home/Error");  // Error page for production
                        }

                        app.UseStaticFiles();  // Serve static files (e.g., images, CSS)
                        app.UseRouting();  // Set up routing for MVC

                        app.UseEndpoints(endpoints =>
                        {
                            // Map controllers and actions to routes
                            endpoints.MapControllerRoute(
                                name: "default",
                                pattern: "{controller=Home}/{action=Index}/{id?}");
                        });
                    });
                });
    }
}
