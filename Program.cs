using Microsoft.EntityFrameworkCore;
using Mission11_Blosil.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookstoreContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:BookstoreConnection"]);
});

builder.Services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute("pagination","Books/{pageNum}", new {Controller = "Home", action = "Index"});
app.MapDefaultControllerRoute();

app.Run();
