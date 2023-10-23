using Bernardino3ITE.Data;
using Bernardino3ITE.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<IMyFakeDataService, MyFakeDataService>();
//Database Connection Service
builder.Services.AddDbContext<AppDBContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDBContext>();
context.Database.EnsureCreated();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
