using ProyectoCrud.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.Extensions.Configuration;
using ProyectoCrud.Interfaces;
using ProyectoCrud.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Add scope to Productos
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();



builder.Services.AddDbContext<ProyectoCrudContext>(options =>
{
    var connetionString = builder.Configuration.GetConnectionString("ProyectoCrudDB");
    options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));

});


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

