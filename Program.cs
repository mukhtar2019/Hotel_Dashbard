using Hotels.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Hotels.Areas.Identity.Data;
using System.Data;
using Hotels.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HotelsUserContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<HotelsUserContext>();
//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI();

builder.Services.AddRazorPages();
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
app.UseAuthentication();

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashbard}/{action=Index}/{id?}");


app.Run();