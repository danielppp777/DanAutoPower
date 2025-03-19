using DanAutoPower.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using DanAutoPower.Data; // ?? ������ YourNamespace � ���� namespace
using DanAutoPower.Models; // ?? ������ ��������� namespace �� ApplicationUser

var builder = WebApplication.CreateBuilder(args);

// ?? ������������� �� ������ �����
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ?? �������� �� Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// ?? �������� �� ���������� � Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // ����� �� Identity ����������!

var app = builder.Build();

// ?? Middleware �� ������������ � �����������
app.UseAuthentication();
app.UseAuthorization();

// ?? ��������� �� ��������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // ?? ���� � ������������ �� Identity UI!

app.Run();
