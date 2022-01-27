
using Trading.App.Core.Trade.Repository;

namespace Trading.App.Repository.Trade
{
    public sealed class StockValidatorRepository : IStockValidatorRepository
    {
        private readonly TradingAppContext _tradingAppContext;

        public StockValidatorRepository(TradingAppContext tradingAppContext)
        {
            _tradingAppContext = tradingAppContext;
        }

        public decimal GetCurrentBalance()
        {
            return _tradingAppContext.CompanyBalances.FirstOrDefault().Balance;
        }
    }
}
