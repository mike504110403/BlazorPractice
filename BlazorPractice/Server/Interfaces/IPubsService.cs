using BlazorPractice.Server.Dto;

namespace BlazorPractice.Server.Interfaces
{
    public interface IPubsService
    {
        /// <summary>
        /// 新增銷售紀錄
        /// </summary>
        /// <param name="saleInfo"></param>
        /// <returns></returns>
        Task CreateAsync(SalesInfoViewModel saleInfo);
        /// <summary>
        /// 取得所有銷售紀錄
        /// </summary>
        /// <returns></returns>
        Task<List<SalesInfoViewModel>> GetAsync();
        /// <summary>
        /// 修改銷售紀錄
        /// </summary>
        /// <param name="saleInfo"></param>
        /// <returns></returns>
        Task UpdateAsync(SalesInfoViewModel saleInfo);
        /// <summary>
        /// 刪除單筆銷售紀錄
        /// </summary>
        /// <param name="orderNum"></param>
        /// <returns></returns>
        Task DeleteAsync(string orderNum);
    }
}
