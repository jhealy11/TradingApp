using Trading.App.Core.Trade.Service;
using Trading.App.Core.Trade.Repository;

namespace Trading.App.Service.Trade
{
    public sealed class PurchaseStockService : IPurchaseStockService
    {
        private readonly IPurchaseValidatorService _stockValidator;
        private readonly IPurchaseStockRepository _purchaseStockRepository;
        private readonly IStockValidatorRepository _stockValidatorRepository;

        public PurchaseStockService(IPurchaseStockRepository purchaseStockRepository, IPurchaseValidatorService stockValidator, IStockValidatorRepository stockValidatorRepository)
        {
            _purchaseStockRepository = purchaseStockRepository;
            _stockValidator = stockValidator;
            _stockValidatorRepository = stockValidatorRepository;
        }

        public async Task PurchaseStock(Core.Trade.Trade trade)
        {

            if(trade.CanSave())
            {
                if(await _stockValidator.CanPurchaseStock(trade))
                {
                    
                    trade.SetNewCashBalance(await _stockValidatorRepository.GetCurrentBalance());
                    await _purchaseStockRepository.SaveTrade(trade);
                }
            }
        }
    }
}
