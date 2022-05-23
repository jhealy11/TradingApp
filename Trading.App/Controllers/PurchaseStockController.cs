using Microsoft.AspNetCore.Mvc;
using Trading.App.Core.Trade.Service;
using Trading.App.Core.Trade.Factory;

namespace Trading.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseStockController : ControllerBase
    {
        private readonly IPurchaseStockService _purchaseStockService;
        private readonly ICreateNewTrade _createNewTrade;

        public PurchaseStockController(IPurchaseStockService purchaseStockService, ICreateNewTrade createNewTrade)
        {
            _purchaseStockService = purchaseStockService;
            _createNewTrade = createNewTrade;
        }

        [HttpPost]
        public async Task<IActionResult> PurchaseStock(Model.TradeViewModel model)
        {
            try
            {
                var trade = _createNewTrade.CreateNewTrade(model.Security, model.TradeDate, model.Price, model.Quantity, model.BuySell);

                await _purchaseStockService.PurchaseStock(trade);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
