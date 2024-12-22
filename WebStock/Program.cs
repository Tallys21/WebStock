using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebStock.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WebStockContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebStockContext")));

var options = builder.Services.AddDbContext<WebStockContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebStockContext")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<WebStockContext>();
    try
    {
        if (dbContext.Database.CanConnect())
        {
            Console.WriteLine("Conexão com o banco de dados bem-sucedida!");
        }
        else
        {
            Console.WriteLine("Não foi possível conectar ao banco de dados.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
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
