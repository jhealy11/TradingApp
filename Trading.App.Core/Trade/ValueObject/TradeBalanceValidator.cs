namespace Trading.App.Core.Trade.ValueObject
{
    public sealed class TradeBalanceValidator
    {
        public bool IsTradeBalanceBreached(Trade trade, decimal currentBalance)
        {
            if ((currentBalance - Math.Abs(trade.TradeTotal())) < 0)
                return true;

            return false;


        }
    }
}
