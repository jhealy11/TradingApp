
namespace Trading.App.Core.Trade.Repository
{
    public interface ITradeRepository
    {
        Task<IEnumerable<Trade>> GetTrades();
    }
}