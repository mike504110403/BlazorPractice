using BlazorPractice.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

// 建立物件
var builder = WebAssemblyHostBuilder.CreateDefault(args);

// 根元件
builder.RootComponents.Add<App>("#app"); // index.html中的id 初始頁面
builder.RootComponents.Add<HeadOutlet>("head::after"); // 改首頁的 head用

// 註冊服務
// Blazor中，由於跳轉頁面的時候不會發出 HTTP 請求，
// 故任何 Scoped 物件一旦建立之後便會跟 Singleton 物件一樣持續存在，
// 直到應用程式結束才會消失 => 效果同 Singleton 
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// 註冊 MudBlazor 服務
builder.Services.AddMudServices();

//// 註冊DBContext
//builder.Services.AddDbContext<PubsContext>(options =>
//         options.UseSqlServer("Server=localhost;Database=Pubs;Trusted_Connection=True;TrustServerCertificate=true;"));
//// 註冊 Api 的 Controller
//builder.Services.AddControllers();
//// 註冊PubsWebAPIService服務
//builder.Services.AddHttpClient<IPubsService, PubsWebAPIService>(client =>
//{
//    client.BaseAddress = new Uri("https://localhost:5001/");
//    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//});


// 運行
await builder.Build().RunAsync();
