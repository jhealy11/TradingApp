namespace Trading.App.Core.Trade.Repository
{
    public interface IPurchaseStockRepository
    {
        Task SaveTrade(Trade trade);
    }
}
