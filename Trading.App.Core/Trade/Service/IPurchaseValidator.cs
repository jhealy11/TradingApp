namespace Trading.App.Core.Trade.Service
{
    public interface IPurchaseValidatorService
    {
        Task<bool> CanPurchaseStock(Trade trade);
    }
}
