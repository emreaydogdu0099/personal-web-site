using EmreAydogduoglu.Business.Extensions;
using Microsoft.EntityFrameworkCore;
using EmreAydogduoglu.UI.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews();

builder.Services.LoadMyServices();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Home/NotFound", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute("admin", "Admin", "Admin/{controller=Home}/{action=Index}/{id?}");
app.MapAreaControllerRoute("identity", "Identity", "Identity/{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();

app.MapRazorPages();

app.Run();
