using BlazorPractice.Server.Dto;
using BlazorPractice.Server.Interfaces;

using System.Text;
using System.Text.Json;
using Microsoft.Identity;

namespace BlazorPractice.Server.Services
{
    /// <summary>
    /// 呼叫 api 的 service
    /// </summary>
    public class PubsWebAPIService : IPubsService
    {
        public HttpClient _httpClient { get; }
        /// <summary>
        /// 注入
        /// </summary>
        /// <param name="httpClient"></param>
        public PubsWebAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// 新增單筆銷售紀錄
        /// </summary>
        /// <param name="saleInfo"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task CreateAsync(SalesInfoViewModel saleInfo)
        {
            var content = JsonSerializer.Serialize(saleInfo);
            using (var stringContent = new StringContent(content, Encoding.UTF8, "application/json"))
            {
                await _httpClient.PostAsync("api/Pubs/CreatSale", stringContent);
            }
        }
        /// <summary>
        /// 查詢所有銷售紀錄
        /// </summary>
        /// <returns></returns>
        public async Task<List<SalesInfoViewModel>> GetAsync()
        {
            var content = await _httpClient.GetStringAsync("api/Pubs/GetSalesList");
            var pubsList = JsonSerializer.Deserialize<List<SalesInfoViewModel>>(content);
            return pubsList ?? new List<SalesInfoViewModel>();
        }
        /// <summary>
        /// 更新單筆銷售紀錄
        /// </summary>
        /// <param name="saleInfo"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UpdateAsync(SalesInfoViewModel saleInfo)
        {
            var content = JsonSerializer.Serialize(saleInfo);
            using (var stringContent = new StringContent(content, Encoding.UTF8, "application/json"))
            {
                await _httpClient.PutAsync("api/Pubs/UpdateSaleByOrdNum", stringContent);
            }
        }
        /// <summary>
        /// 刪除單筆銷售紀錄
        /// </summary>
        /// <param name="orderNum"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task DeleteAsync(string orderNum)
        {
            await _httpClient.DeleteAsync($"api/Pubs/DeleteSaleByOrdNum/{orderNum}");
        }
    }
}
