using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trading.App.Core.Trade.Service;
using Trading.App.Core.Trade.Factory;

namespace Trading.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellStockController : ControllerBase
    {
        private readonly ISellStockService _sellStockService;
        private readonly ICreateNewTrade _createNewTrade;
        public SellStockController(ISellStockService sellStockService, ICreateNewTrade createNewTrade)
        {
            _sellStockService = sellStockService;
            _createNewTrade = createNewTrade;
        }

        [HttpPost]
        public async Task<IActionResult> SellStock(Model.TradeViewModel model)
        {
            try
            {
                try
                {
                    var trade = _createNewTrade.CreateNewTrade(model.Security, model.TradeDate, model.Price, model.Quantity, model.BuySell);

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
