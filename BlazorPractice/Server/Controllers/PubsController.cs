using BlazorPractice.Server.Dto;
using BlazorPractice.Server.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorPractice.Server.Controllers
{
    [Route("api/[controller]/[action]")]
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
        /// <summary>
        /// 取得銷售紀錄
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetSalesList")]
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
    }
}
