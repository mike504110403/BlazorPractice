using BlazorPractice.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

// �إߪ���
var builder = WebAssemblyHostBuilder.CreateDefault(args);

// �ڤ���
builder.RootComponents.Add<App>("#app"); // index.html����id ��l����
builder.RootComponents.Add<HeadOutlet>("head::after"); // �ﭺ���� head��

// ���U�A��
// Blazor���A�ѩ���୶�����ɭԤ��|�o�X HTTP �ШD�A
// �G���� Scoped ����@���إߤ���K�|�� Singleton ����@�˫���s�b�A
// �������ε{�������~�|���� => �ĪG�P Singleton 
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// ���U MudBlazor �A��
builder.Services.AddMudServices();

//// ���UDBContext
//builder.Services.AddDbContext<PubsContext>(options =>
//         options.UseSqlServer("Server=localhost;Database=Pubs;Trusted_Connection=True;TrustServerCertificate=true;"));
//// ���U Api �� Controller
//builder.Services.AddControllers();
//// ���UPubsWebAPIService�A��
//builder.Services.AddHttpClient<IPubsService, PubsWebAPIService>(client =>
//{
//    client.BaseAddress = new Uri("https://localhost:5001/");
//    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//});


// �B��
await builder.Build().RunAsync();
