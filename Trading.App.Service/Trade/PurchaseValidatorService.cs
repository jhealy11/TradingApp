using Trading.App.Core.Trade.Service;
using Trading.App.Core.Trade.Repository;
using Trading.App.Core.Trade.ValueObject;

namespace Trading.App.Service.Trade
{
    public sealed class PurchaseValidatorService : IPurchaseValidatorService
    {
        private readonly IStockValidatorRepository _stockValidatorRepository;

        public PurchaseValidatorService(IStockValidatorRepository stockValidatorRepository)
        {
            _stockValidatorRepository = stockValidatorRepository;
        }

        public bool CanPurchaseStock(Core.Trade.Trade trade)
        {
            var balance = _stockValidatorRepository.GetCurrentBalance();

            var tradeBalanceValidator = new TradeBalanceValidator();

            if (tradeBalanceValidator.IsTradeBalanceBreached(trade, balance))
                throw new Exception("Trade Balance Breached");

            return true;

        }
    }
}
