using BlazorPractice.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

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

// 運行
await builder.Build().RunAsync();
