using BlazorPractice.Server.Dto;
using BlazorPractice.Server.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorPractice.Server.Controllers
{
    [Route($"api/[controller]/")]
    [ApiController]
    public class PubsController : ControllerBase
    {
        private readonly PubsContext _context;
        /// <summary>
        /// pubs 資料處理
        /// </summary>
        /// <param name="context"></param>
        public PubsController(PubsContext context)
        {
            _context = context;
        }

        // todo: 玩玩看core的 findAsnyc寫法


        /// <summary>
        /// 新增單筆銷售紀錄
        /// </summary>
        /// <param name="saleInfo"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreatSale"), Route("CreatSale")]
        public async Task<IActionResult> CreatSale([FromBody] SalesInputModel sale)
        {
            if (ModelState.IsValid)
            {
                var saleAdd = new Sale()
                {
                    StorId = sale.StorId,
                    OrdNum = sale.OrderNum,
                    OrdDate = sale.OrderDate,
                    Qty = sale.Qty,
                    TitleId = sale.TitleId,
                    Payterms = sale.Payterms,
                };
                _context.Sales.Add(saleAdd);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
        /// <summary>
        /// 取得銷售紀錄
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetSalesList"), Route("GetSalesList")]
        public List<SalesInfoViewModel> GetSalesList()
        {
            var sales = _context.Sales.Include(x => x.Title).Include(x => x.Stor)
                                      .Select(m => new SalesInfoViewModel()
                                      {
                                          StorName = m.Stor.StorName,
                                          OrderNum = m.OrdNum,
                                          TitleName = m.Title.Title1,
                                          OrderDate = m.OrdDate,
                                          Qty = m.Qty,
                                          Payterms = m.Payterms,
                                      }).ToList();
            return sales;
        }
        /// <summary>
        /// 更新單筆銷售紀錄
        /// </summary>
        /// <param name="saleInfo"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateSaleByOrdNum"), Route("UpdateSaleByOrdNum")]
        public async Task<IActionResult> UpdateSaleByOrdNum([FromBody] SalesInputModel sale)
        {
            if (ModelState.IsValid)
            {
                //var record = await _context.Sales.FindAsync(sale.OrderNum);
                var record = _context.Sales.Where(x => x.OrdNum == sale.OrderNum).FirstOrDefault();
                if (record != null)
                {
                    record.StorId = sale.StorId;
                    record.OrdDate = sale.OrderDate;
                    record.Qty = sale.Qty;
                    record.TitleId = sale.TitleId;
                    record.Payterms = sale.Payterms;
                }

                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
        /// <summary>
        /// 刪除單筆銷售紀錄
        /// </summary>
        /// <param name="orderNum"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteSaleByOrdNum"), Route("DeleteSaleByOrdNum")]
        public async Task<IActionResult> DeleteSaleByOrdNum(string? orderNum)
        {
            //var sale = await _context.Sales.FindAsync(orderNum);
            var sale = _context.Sales.Where(x => x.OrdNum == orderNum).FirstOrDefault();

            if (sale == null)
            {
                return NotFound();
            }
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
