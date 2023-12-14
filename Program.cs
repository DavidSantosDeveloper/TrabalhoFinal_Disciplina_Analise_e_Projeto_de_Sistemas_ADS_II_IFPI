
using Microsoft.EntityFrameworkCore;
using FranciscoDavidSantosSousa.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string mysqlconnection = builder.Configuration.GetConnectionString("MyDbContext");
builder.Services.AddDbContext<FranciscoDavidSantosSousa.Models.MyDbContext>(options => options.UseMySql(mysqlconnection, ServerVersion.AutoDetect(mysqlconnection)));


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
