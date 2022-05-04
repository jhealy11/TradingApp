using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trading.App.Core.Trade.Service;

namespace Trading.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellStockController : ControllerBase
    {
        private readonly ISellStockService _sellStockService;

        public SellStockController(ISellStockService sellStockService)
        {
            _sellStockService = sellStockService;
        }

        public async Task<IActionResult> SellStock(Model.TradeViewModel model)
        {
            try
            {
                try
                {
                    var tradeType = Core.Trade.ValueObject.TradeType.Sell;

                    var trade = new Core.Trade.Trade(model.Id, model.Security, model.TradeDate, model.Price, model.Quantity, tradeType);

                    await _sellStockService.SellStock(trade);

                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
