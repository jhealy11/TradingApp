
namespace Trading.App.Core.Trade.Factory
{
    public interface ICreateNewTrade
    {
        Trade CreateNewTrade(string security, DateTime tradeDate, decimal price, int quantity, string tradeType);
    }
}
