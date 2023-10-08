using System.Text.Json.Serialization;

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
        [JsonPropertyName("StorName")]
        public string? StorName { get; set; }
        /// <summary>
        /// 書名
        /// </summary>
        [JsonPropertyName("TitleName")]
        public string? TitleName { get; set; }
        /// <summary>
        /// 訂單編號
        /// </summary>
        [JsonPropertyName("OrderNum")]
        public string? OrderNum { get; set; }
        /// <summary>
        /// 銷售日期
        /// </summary>
        [JsonPropertyName("OrderDate")]
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 銷售數量
        /// </summary>
        [JsonPropertyName("Qty")]
        public short Qty { get; set; }
        /// <summary>
        /// 付款條件
        /// </summary>
        [JsonPropertyName("Payterms")]
        public string? Payterms { get; set; }

    }
}
