var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Star}/{action=Index}/{id?}");

app.Run();