using Trading.App.Core.Trade.Repository;

namespace Trading.App.Repository.Trade
{
    public sealed class PurchaseStockRepository : IPurchaseStockRepository
    {
        private readonly TradingAppContext _appContext; 
        public PurchaseStockRepository(TradingAppContext appContext)
        {
            _appContext = appContext;
        }
        public Task SaveTrade(Core.Trade.Trade trade)
        {
            throw new NotImplementedException();
        }
    }
}
