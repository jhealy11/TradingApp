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
        public async Task<IActionResult> PurchaseStock(Model.TradeViewModel model)
        {
            try
            {

                var trade = new Core.Trade.Trade(model.Id, model.Security, model.TradeDate, model.Price, model.Quantity, new Core.Trade.ValueObject.TradeType { Description = "Buy", Id = 1});

                _purchaseStockService.PurchaseStock(trade);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
