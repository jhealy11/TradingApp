
namespace Trading.App.Core.Trade.Repository
{
    public interface IStockValidatorRepository
    {
        Task<decimal> GetCurrentBalance();
    }
}
