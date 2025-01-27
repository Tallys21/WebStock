using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebStock.Data;
using WebStock.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebStockContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebStockContext")));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CategoryService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<WebStockContext>();
        var seeding = scope.ServiceProvider.GetRequiredService<SeedingService>();

        await seeding.SeedAsync();
    }
}

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
