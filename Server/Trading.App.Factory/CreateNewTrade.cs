using Trading.App.Core.Trade;
using Trading.App.Core.Trade.Factory;

namespace Trading.App.Factory
{
    public sealed class CreateNewTrade : ICreateNewTrade
    {
        
        Trade ICreateNewTrade.CreateNewTrade(string security, DateTime tradeDate, decimal price, int quantity, string tradeType)
        {
            var convertedTradeType = Enum.Parse<Core.Trade.ValueObject.TradeType>(tradeType);

            var id = Guid.NewGuid();

            var trade = new Trade(id, security, tradeDate, price, quantity, convertedTradeType);

            return trade;
        }
    }
}