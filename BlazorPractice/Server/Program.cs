using BlazorPractice.Server.Models;

using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
// 建立WebApplicationBuilder 實例
var builder = WebApplication.CreateBuilder(args);

// 註冊MVC服務
builder.Services.AddControllersWithViews();
// 註冊RazorPage
builder.Services.AddRazorPages();
// 註冊Blazor Server
builder.Services.AddServerSideBlazor();
// 註冊WeatherForecastService 單例
//builder.Services.AddSingleton<WeatherForecastService>();
// 註冊DBContext
builder.Services.AddDbContext<PubsContext>(options =>
         options.UseSqlServer("Server=localhost;Database=Pubs;Trusted_Connection=True;TrustServerCertificate=true;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// http導https
app.UseHttpsRedirection();
//  提供 Blazor WebAssembly js
app.UseBlazorFrameworkFiles();
// 靜態文件中介軟體
app.UseStaticFiles();
// 設定路由
app.UseRouting();


app.MapRazorPages();
app.MapControllers();
// SignalR Hub
app.MapBlazorHub();
// 回退路由
app.MapFallbackToFile("index.html");

app.Run();
