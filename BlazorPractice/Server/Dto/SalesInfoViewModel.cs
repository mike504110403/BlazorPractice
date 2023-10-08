namespace BlazorPractice.Server.Dto
{
    /// <summary>
    /// 銷售紀錄顯示模型
    /// </summary>
    public class SalesInfoViewModel
    {
        /// <summary>
        /// 書店名稱
        /// </summary>
        public string? StorName { get; set; }
        /// <summary>
        /// 書名
        /// </summary>
        public string? TitleName { get; set; }
        /// <summary>
        /// 訂單編號
        /// </summary>
        public string? OrderNum { get; set; }
        /// <summary>
        /// 銷售日期
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 銷售數量
        /// </summary>
        public short Qty { get; set; }
        /// <summary>
        /// 付款條件
        /// </summary>
        public string? Payterms { get; set; }

    }
}
