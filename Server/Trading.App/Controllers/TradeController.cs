using Microsoft.AspNetCore.Mvc;
using Trading.App.Core.Trade.Repository;
namespace Trading.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController : Controller
    {
        private readonly ITradeRepository _tradeRepository;


        public TradeController(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {

                var data = new List<Model.TradeViewModel>();
                var trades = await _tradeRepository.GetTrades();
                foreach(var trade in trades)
                {
                    var item = new Model.TradeViewModel
                    {
                        Id = trade.Id,
                        BuySell = trade.TradeType.ToString(),
                        Price = trade.Price,
                        Quantity = trade.Quantity,
                        Security = trade.Security,
                        TradeDate = trade.TradeDate,
                    };

                    data.Add(item);
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
