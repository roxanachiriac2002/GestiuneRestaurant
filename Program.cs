using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using GestiuneRestaurant.Data;

var builder = WebApplication.CreateBuilder(args);

// Adauga serviciile
builder.Services.AddDbContext<RestaurantContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantContext")));

// Pastreaza Razor Pages ?i adauga suport pentru MVC
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews(); // Pentru MVC

var app = builder.Build();

// Configureaza pipeline-ul de cereri HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); // Asigura-te ca aceasta ruta corespunde paginii tale de erori
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configurarea rutelor pentru Razor Pages ?i MVC
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
