using BlazorPractice.Server.Dto;
using BlazorPractice.Server.Interfaces;

using System.Text.Json;

namespace BlazorPractice.Server.Services
{
    public class PubsWebAPIService : IPubsService
    {
        public HttpClient _httpClient { get; }

        public PubsWebAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /// <summary>
        /// 查詢所有銷售紀錄
        /// </summary>
        /// <returns></returns>
        public async Task<List<SalesInfoViewModel>> GetAsync()
        {
            var content = await _httpClient.GetStringAsync("api/SalesInfo");
            var pubsList = JsonSerializer.Deserialize<List<SalesInfoViewModel>>(content);
            return pubsList ?? new List<SalesInfoViewModel>();
        }
    }
}
