/*
 * Author: Brianna Ordaz
 * Course: COMP-003B: ASP.NET Core
 * Faculty: Jonathan Cruz
 * Purpose: To build a modular and structured ASP.NET Core MVC web application
 */

using COMP003B.Assignment2.Middleware;

namespace COMP003B.Assignment2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
    
        //Middleware 
        
        app.UseHttpsRedirection();
        
        app.UseStaticFiles();
        
        //registered middleware for RequestTrackerMiddleware
        app.UseMiddleware<COMP003B.Assignment2.Middleware.RequestTrackerMiddleware>();
            
        //added welcome page middleware
        app.UseWelcomePage("/welcome");


        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}