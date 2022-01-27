namespace Trading.App.Core.Trade.Service
{
    public interface IPurchaseValidatorService
    {
        bool CanPurchaseStock(Trade trade);
    }
}
