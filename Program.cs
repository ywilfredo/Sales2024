using Microsoft.EntityFrameworkCore;
using Sales.Data;
using Sales.Repository.Implementations;
using Sales.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//conexion
builder.Services.AddDbContext<SalesDbContext>(options => {
    options.UseSqlite(
        builder.Configuration["ConnectionStrings:SalesDbConnection"]);
});

//Inyecciones 
builder.Services.AddScoped<ICountryRepository, CountryRepository>();



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
