namespace Trading.App.Core.Trade.Repository
{
    public interface ISellStockRepository
    {
        Task SellStock(Trade trade);
    }
}
