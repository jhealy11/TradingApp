using Trading.App.Core.Trade.Service;
using Trading.App.Core.Trade.Repository;
using Trading.App.Core.Trade.ValueObject;
using Trading.App.Core.Trade.Exception;

namespace Trading.App.Service.Trade
{
    public sealed class PurchaseValidatorService : IPurchaseValidatorService
    {
        private readonly IStockValidatorRepository _stockValidatorRepository;

        public PurchaseValidatorService(IStockValidatorRepository stockValidatorRepository)
        {
            _stockValidatorRepository = stockValidatorRepository;
        }

        public async Task<bool> CanPurchaseStock(Core.Trade.Trade trade)
        {
            var balance = await _stockValidatorRepository.GetCurrentBalance();

            var tradeBalanceValidator = new TradeBalanceValidator();

            if (tradeBalanceValidator.IsTradeBalanceBreached(trade, balance))
                throw new TradeBalanceBreachedException("Trade Balance Breached");

            return true;

        }
    }
}