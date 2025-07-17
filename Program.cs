using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuperHeroApp.Data;
using SuperHeroApp.Models;

namespace SuperHeroApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuración de EF Core con PostgreSQL
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Configuración de Identity con el modelo personalizado 'User'
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            // Registramos servicios de Telerik UI
            builder.Services.AddKendo();

            // Activamos controladores con vistas (MVC)
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //  Manejo de errores y seguridad HTTPS
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Middleware para autenticación y autorización
            app.UseAuthentication();
            app.UseAuthorization();

            // Ruta principal
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
