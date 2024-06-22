using Microsoft.EntityFrameworkCore;
using my_resturant.Models;
using Microsoft.AspNetCore.Http;//new

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMemoryCache();//new

builder.Services.AddSession();//new

builder.Services.AddDbContext<resturantDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("resturantContextStr")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession(); //new

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
