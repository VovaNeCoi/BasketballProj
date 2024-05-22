using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using BasketballProj.Data.Interfaces;
using BasketballProj.Data.Mocks;
using BasketballProj.Data.Repository;
using Microsoft.EntityFrameworkCore;
using BasketballProj.Models.DB;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddTransient < ITeamsReportsManaging, TeamsReportsManagingRepository>();
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NbaContext>(options => options.UseSqlServer(connection));

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
