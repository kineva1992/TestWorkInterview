using Microsoft.EntityFrameworkCore;
using VswTask.Models;

var builder = WebApplication.CreateBuilder(args);

// Connections string
var connString = builder.Configuration.GetConnectionString("ConnectonString:DeftConnection");
// Add services to the container.
builder.Services.AddControllersWithViews();
// Add connection string 
builder.Services.AddDbContext<DbContextPipe>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("MvcMovieContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
