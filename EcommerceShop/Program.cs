using EcommerceShop.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();

///abdullah HI ///


builder.Services.AddDbContext<MyDbcontext>(a =>
a.UseSqlServer("Server=DESKTOP-KHBGNKV\\SQLEXPRESS;Database=ecommerce_shop;trusted_connection=True;TrustServerCertificate=true;")
);

builder.Services.AddDbContext<registerdb>(a =>
a.UseSqlServer("Server=DESKTOP-KHBGNKV\\SQLEXPRESS;Database=ecommerce_shop;trusted_connection=True;TrustServerCertificate=true;")
 );


builder.Services.AddHttpContextAccessor();



builder.Services.AddSession();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
