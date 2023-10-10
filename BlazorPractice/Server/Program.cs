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

// �إ�WebApplicationBuilder ���
var builder = WebApplication.CreateBuilder(args);
// ���URazorPage
builder.Services.AddRazorPages();
// ���UBlazor Server
builder.Services.AddServerSideBlazor();
// ���UDBContext
builder.Services.AddDbContext<PubsContext>(options =>
         options.UseSqlServer("Server=localhost;Database=Pubs;Trusted_Connection=True;TrustServerCertificate=true;"));

// ���U Api �� Controller
builder.Services.AddControllers();

// ���UPubsWebAPIService�A��
builder.Services.AddHttpClient<IPubsService, PubsWebAPIService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7186/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});
// ���U MudBlazor �A��
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
// http��https
app.UseHttpsRedirection();
// �R�A��󤤤��n��
app.UseStaticFiles();
// �]�w����
app.UseRouting();

// api �i�Ӫ����hpage
app.MapControllers();
// SignalR Hub
app.MapBlazorHub();
// �^�h����
app.MapFallbackToPage("/_Host");

app.Run();
