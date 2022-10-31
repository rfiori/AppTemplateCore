using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AppTemplateCore.Configuration;
using AppTemplateCore.CrossCutting.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AppTemplateCoreContextConn");

builder.Services.AddDbContext<AppTemplateCoreContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppTemplateCoreUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppTemplateCoreContext>();
builder.Services.Configure<IdentityOptions>(o =>
{
    o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
    o.Lockout.MaxFailedAccessAttempts = 5;
    o.SignIn.RequireConfirmedEmail = true;
});
builder.Services.ConfigureApplicationCookie(o =>
{
    o.Cookie.Name = "AppTemplateCore";
    o.Cookie.HttpOnly = true;
    o.SlidingExpiration = true;
});

builder.Services.AddControllersWithViews();
builder.Services.AddPolicyConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

// Configure Routers
app.MapControllerRoute(
      name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
