using Microsoft.EntityFrameworkCore;
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

        public async Task<decimal> GetCurrentBalance()
        {
            var result =  await _tradingAppContext.CompanyBalances.SingleOrDefaultAsync();
            if (result == null)
                return 0;

            return result.Balance;
        }
    }
}
