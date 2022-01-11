using Trading.App.Core.Trade.Repository;

namespace Trading.App.Repository.Trade
{
    public sealed class TradeRepository : ITradeRepository
    {
        private readonly TradingAppContext _context;
        public TradeRepository(TradingAppContext context)
        {
            _context = context;
        }

        public IEnumerable<Core.Trade.Trade> GetTrades()
        {
            var trades = _context.Trades;

            var tradeModel = new List<Core.Trade.Trade>();

            foreach (var trade in trades)
            {
                var type = new Trading.App.Core.Trade.ValueObject.TradeType() { Id = 1, Description = "Sell"};

                tradeModel.Add(new Core.Trade.Trade(trade.Id, trade.Security, trade.TradeDate, trade.Price, trade.Quantity, type));
            }

            return tradeModel;
        }
    }
}