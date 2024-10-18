using PotatoWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using MailKit;
using PotatoWebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GoodbyepotatoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("goodbyepotato")));
builder.Services.AddScoped<SendEmail>();

//設定開放網域
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.WithOrigins("http://localhost:5173").WithHeaders("*").WithMethods("*"));
});

//快取
builder.Services.AddControllers(); // 加入 MVC 控制器服務
builder.Services.AddMemoryCache(); // 加入內存快取服務

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("AllowAll");  //允許跨網域讀取

app.UseStaticFiles();//傳送靜態圖片

app.UseAuthorization();

app.MapControllers();

app.Run();
