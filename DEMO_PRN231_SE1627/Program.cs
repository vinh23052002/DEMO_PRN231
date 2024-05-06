using DEMO_PRN231_SE1627.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MySaleDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Products}/{action=Index}/{id?}");
app.Run();
