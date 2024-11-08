using goodbyecouchpotato.Data;
using goodbyecouchpotato.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using goodbyecouchpotato.Utilities;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<GoodbyepotatoContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("goodbyepotato")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<MailService>();

//========身分驗證貼上Start========
builder.Services.Configure<IdentityOptions>(options => {
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireNonAlphanumeric = true;
	options.Password.RequireUppercase = true;
	options.Password.RequiredLength = 8;
	options.Password.RequiredUniqueChars = 1;

	//鎖幾分
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
	//輸錯幾次鎖
	options.Lockout.MaxFailedAccessAttempts = 3;
	options.Lockout.AllowedForNewUsers = true;

	options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
	//驗證唯一信箱
	options.User.RequireUniqueEmail = true;
	//需不需要驗證信箱
	options.SignIn.RequireConfirmedEmail = false;
});
builder.Services.ConfigureApplicationCookie(options => {
	options.Cookie.HttpOnly = true;
	options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
	//options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
	options.LoginPath = "/Identity/Account/Login";
	options.AccessDeniedPath = "/Identity/Account/AccessDenied";
	options.SlidingExpiration = true;
});
//========身分驗證貼上End========
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.WithOrigins("http://localhost:5173", "http://localhost:7180").SetIsOriginAllowedToAllowWildcardSubdomains()
                .AllowAnyHeader()
                .AllowAnyMethod());
});

//處理靜態文件
builder.Services.AddDirectoryBrowser(); // 允許瀏覽目錄
var app = builder.Build();
app.UseCors("AllowAll");

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
app.Use(async (context, next) =>
{
	context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
	context.Response.Headers["Pragma"] = "no-cache";
	context.Response.Headers["Expires"] = "-1";

	await next();
});

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers["Cache-Control"] = "no-store";
    }
});

app.UseRouting();

// 必須要有 Authentication 在 Authorization 之前
app.UseAuthentication();
app.UseAuthorization();
//area�n��bdefault�e���~�|�QŪ����
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{area=DataAnalysis}/{controller=Player}/{action=Index}/{id?}");
app.MapRazorPages();

var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

// 調用角色初始化方法
await RoleInitializer.InitializeRoles(services);


app.Run();
