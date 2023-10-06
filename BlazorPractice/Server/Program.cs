using BlazorPractice.Server.Models;

using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
// �إ�WebApplicationBuilder ���
var builder = WebApplication.CreateBuilder(args);

// ���UMVC�A��
builder.Services.AddControllersWithViews();
// ���URazorPage
builder.Services.AddRazorPages();
// ���UBlazor Server
builder.Services.AddServerSideBlazor();
// ���UWeatherForecastService ���
//builder.Services.AddSingleton<WeatherForecastService>();
// ���UDBContext
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
// http��https
app.UseHttpsRedirection();
//  ���� Blazor WebAssembly js
app.UseBlazorFrameworkFiles();
// �R�A��󤤤��n��
app.UseStaticFiles();
// �]�w����
app.UseRouting();


app.MapRazorPages();
app.MapControllers();
// SignalR Hub
app.MapBlazorHub();
// �^�h����
app.MapFallbackToFile("index.html");

app.Run();
