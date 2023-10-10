using BlazorPractice.Server.Interfaces;
using BlazorPractice.Server.Models;
using BlazorPractice.Server.Services;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using BlazorPractice.Server;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using Microsoft.AspNetCore;

WebHost.CreateDefaultBuilder(args).UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
WebHost.CreateDefaultBuilder(args).UseEnvironment(Environments.Development);

// 建立WebApplicationBuilder 實例
var builder = WebApplication.CreateBuilder(args);
// 註冊RazorPage
builder.Services.AddRazorPages();
// 註冊Blazor Server
builder.Services.AddServerSideBlazor();
// 註冊DBContext
builder.Services.AddDbContext<PubsContext>(options =>
         options.UseSqlServer("Server=localhost;Database=Pubs;Trusted_Connection=True;TrustServerCertificate=true;"));

// 註冊 Api 的 Controller
builder.Services.AddControllers();

// 註冊PubsWebAPIService服務
builder.Services.AddHttpClient<IPubsService, PubsWebAPIService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7186/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});
// 註冊 MudBlazor 服務
builder.Services.AddMudServices();

builder.Services.AddSignalR();

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
// 靜態文件中介軟體
app.UseStaticFiles();
// 設定路由
app.UseRouting();

// api 進來的不去page
app.MapControllers();
// SignalR Hub
app.MapBlazorHub();
// 回退頁面
app.MapFallbackToPage("/_Host");

app.Run();
