using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Assignment1.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Assignment1Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Assignment1ContextLite") ?? throw new InvalidOperationException("Connection string 'Assignment1Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
