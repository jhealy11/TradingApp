
namespace Trading.App.Core.Trade.Repository
{
    public interface ITradeRepository
    {
        IEnumerable<Trade> GetTrades();
    }
}