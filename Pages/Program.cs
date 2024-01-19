using Microsoft.EntityFrameworkCore;
using Pages.Data;
using Pages.Services.Implementation;
using Pages.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PagesUDDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddScoped<IPagesService, PagesService>();
builder.Services.AddScoped<ISectionService,SectionService>();


var app = builder.Build();
var env = builder.Environment;
Images.Initialize(env);



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
    pattern: "{controller=Pages}/{action=Index}/{id?}");

app.Run();
