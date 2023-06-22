using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Context
var connectionStr = builder.Configuration.GetConnectionString("FAJustBlogContextConnection");
builder.Services.AddDbContext<JustBlogContext>(option => option.UseSqlServer(connectionStr));

builder.Services.AddDefaultIdentity<FAJustBlogUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>().AddEntityFrameworkStores<JustBlogContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//add lifetime service
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = $"/Areas/Identity/Pages/Account/Login.cshtml";
    option.LogoutPath = $"/Areas/Identity/Pages/Account/Logout.cshtml";
    option.AccessDeniedPath = $"/hanchetruycap.html";
});

builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
    {
        // Đọc thông tin Authentication:Google từ appsettings.json
        IConfigurationSection googleAuthNSection = builder.Configuration.GetSection("Authentication:Google");

        // Thiết lập ClientID và ClientSecret để truy cập API google
        googleOptions.ClientId = googleAuthNSection["ClientId"];
        googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
        // Cấu hình Url callback lại từ Google (không thiết lập thì mặc định là /signin-google)
        googleOptions.CallbackPath = "/login-form-google";

    })
     .AddFacebook(facebookOptions =>
     {
         // Đọc cấu hình
         IConfigurationSection facebookAuthNSection = builder.Configuration.GetSection("Authentication:Facebook");
         facebookOptions.AppId = facebookAuthNSection["AppId"];
         facebookOptions.AppSecret = facebookAuthNSection["AppSecret"];
         // Thiết lập đường dẫn Facebook chuyển hướng đến
         facebookOptions.CallbackPath = "/login-form-facebook";
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
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoint =>
{
    app.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
        );

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();
