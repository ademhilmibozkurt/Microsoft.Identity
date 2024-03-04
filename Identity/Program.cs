using Identity.Contexts;
using Identity.CustomDescriber;
using Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Security.Policy;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddIdentity<AppUser, AppRole>(opt=> 
        {
            opt.Password.RequireDigit = false;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireNonAlphanumeric = false;
            opt.SignIn.RequireConfirmedEmail = true;
            opt.Lockout.MaxFailedAccessAttempts = 5;

        }).AddErrorDescriber<CustomErrorDescriber>().AddEntityFrameworkStores<IdContext>();

        builder.Services.ConfigureApplicationCookie(opt =>
        {
            opt.Cookie.Name = "CookieName";
            opt.Cookie.HttpOnly = true;
            opt.Cookie.SameSite = SameSiteMode.Strict;
            opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            opt.ExpireTimeSpan = TimeSpan.FromDays(10);
            opt.LoginPath = new PathString("/Home/SignIn");
            opt.AccessDeniedPath = new PathString("/Home/AccessDenied");
        });

        builder.Services.AddDbContext<IdContext>(opt => 
        {
            opt.UseSqlServer("server = (localdb)\\mssqllocaldb; database = IdentityDb integrated security = true;");
        });

        builder.Services.AddControllersWithViews();
        
        var app = builder.Build();

        app.UseStaticFiles();
        app.UseStaticFiles(new StaticFileOptions
        {
            RequestPath = "/node_modules",
            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules"))
        });

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapDefaultControllerRoute();

        app.Run();
    }
}