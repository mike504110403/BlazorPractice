using BlazorPractice.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
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

// �B��
await builder.Build().RunAsync();
