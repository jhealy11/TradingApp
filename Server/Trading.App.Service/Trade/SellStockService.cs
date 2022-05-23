using Trading.App.Core.Trade.Service;
using Trading.App.Core.Trade.Repository;

namespace Trading.App.Service.Trade
{
    public sealed class SellStockService : ISellStockService
    {
        private readonly ISellStockRepository _sellStockRepository;
        private readonly IStockValidatorRepository _stockValidatorRepository;

        public SellStockService(ISellStockRepository sellStockRepository, IStockValidatorRepository stockValidatorRepository)
        {
            _sellStockRepository = sellStockRepository;
            _stockValidatorRepository = stockValidatorRepository;
        }

        public async Task SellStock(Core.Trade.Trade trade)
        {
            if(trade.CanSave())
            {
                trade.SetNewCashBalance(await _stockValidatorRepository.GetCurrentBalance());
                await _sellStockRepository.SellStock(trade);
            }
        }
    }
}
