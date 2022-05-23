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
        public async Task SaveTrade(Core.Trade.Trade trade)
        {
            using(var transaction = await _appContext.Database.BeginTransactionAsync())
            {
                var tradeType = _appContext.TradeTypes.FirstOrDefault(m => m.Id == (int)trade.TradeType);

                Model.Trade data = new Model.Trade()
                {
                    Id = trade.Id,
                    Price = trade.Price,
                    Quantity = trade.Quantity,
                    Security = trade.Security,
                    TradeDate = trade.TradeDate,
                    Total = trade.TradeTotal(),
                    TradeType = tradeType
                };

                await _appContext.Trades.AddAsync(data);
                await _appContext.SaveChangesAsync();


                var balance = _appContext.CompanyBalances.FirstOrDefault();
                if(balance != null)
                    balance.Balance = trade.GetCashBalance();
                else
                {
                    balance = new Model.CompanyBalance();
                    balance.Balance = trade.GetCashBalance();

                    await _appContext.CompanyBalances.AddAsync(balance);
                }

                await _appContext.SaveChangesAsync();


                transaction.Commit();
            }
        }
    }
}
