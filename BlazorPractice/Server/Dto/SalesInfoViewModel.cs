using Microsoft.AspNetCore.Components;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace BlazorPractice.Server.Dto
{
    /// <summary>
    /// 銷售紀錄顯示模型
    /// </summary>
    public class SalesInfoViewModel : ICloneable
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
        // 使用淺層複製相同物件
        public SalesInfoViewModel Clone()
        {
            return ((ICloneable)this).Clone() as SalesInfoViewModel;
        }
        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
    }
    /// <summary>
    /// 銷售紀錄輸入模型
    /// </summary>
    public class SalesInputModel : ComponentBase
    {
        /// <summary>
        /// 書店名稱
        /// </summary>
        [JsonPropertyName("StorId")]
        public string? StorId { get; set; }
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
        [Required(ErrorMessage = "數量必填！")]
        public short Qty { get; set; }
        /// <summary>
        /// 付款條件
        /// </summary>
        [JsonPropertyName("Payterms")]
        public string? Payterms { get; set; }
        /// <summary>
        /// 書名
        /// </summary>
        [JsonPropertyName("TitleId")]
        public string? TitleId { get; set; }
    }

}
