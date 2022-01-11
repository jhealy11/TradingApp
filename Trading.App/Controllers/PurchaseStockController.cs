using Microsoft.AspNetCore.Mvc;
using Trading.App.Core.Trade.Repository;
using Trading.App.Core.Trade.Service;

namespace Trading.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseStockController : ControllerBase
    {
        private readonly ITradeRepository _tradeRepository;

        private readonly IPurchaseStockService _purchaseStockService;

        public PurchaseStockController(IPurchaseStockService purchaseStockService, ITradeRepository tradeRepository)
        {
            _purchaseStockService = purchaseStockService;
            _tradeRepository = tradeRepository;
        }

        public PurchaseStockController(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }
        public async Task<IActionResult> PurchaseStock()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
