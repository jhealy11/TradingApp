using Trading.App.Core.Trade;
using Trading.App.Core.Trade.Factory;

namespace Trading.App.Factory
{
    public sealed class CreateNewTrade : ICreateNewTrade
    {
        
        Trade ICreateNewTrade.CreateNewTrade(string security, DateTime tradeDate, decimal price, int quantity, string tradeType)
        {
            Enum.TryParse<Core.Trade.ValueObject.TradeType>(tradeType, out var convertedTradeType);


            if(!Enum.IsDefined<Core.Trade.ValueObject.TradeType>(convertedTradeType))
            {
                throw new Core.Trade.Exception.UnknownTradeTypeException($"Unknown Trade Type {tradeType}");
            }

            var id = Guid.NewGuid();

            var trade = new Trade(id, security, tradeDate, price, quantity, convertedTradeType);

            return trade;
        }
    }
}