using DanAutoPower.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using DanAutoPower.Data; // ?? Замени YourNamespace с твоя namespace
using DanAutoPower.Models; // ?? Добави правилния namespace за ApplicationUser

var builder = WebApplication.CreateBuilder(args);

// ?? Конфигуриране на базата данни
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ?? Добавяне на Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// ?? Добавяне на контролери и Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Важно за Identity страниците!

var app = builder.Build();

// ?? Middleware за аутентикация и авторизация
app.UseAuthentication();
app.UseAuthorization();

// ?? Зареждане на маршрути
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // ?? Това е задължително за Identity UI!

app.Run();
