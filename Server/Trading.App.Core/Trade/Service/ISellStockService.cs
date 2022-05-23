
namespace Trading.App.Core.Trade.Service
{
    public interface ISellStockService
    {
        Task SellStock(Core.Trade.Trade trade);
    }
}
