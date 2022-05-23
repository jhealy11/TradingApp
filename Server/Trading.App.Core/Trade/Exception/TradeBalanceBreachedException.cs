using System;
using System.Runtime.Serialization;

namespace Trading.App.Core.Trade.Exception
{
    /// <summary>
    /// A custom exception that is thrown if the balance of the account goes below 0 on a purhcase trade. 
    /// i.e. we don't have enough cash to puchase the stock
    /// </summary>
    [Serializable]
    public class TradeBalanceBreachedException : System.Exception
    {
        public TradeBalanceBreachedException(string message)
            : base(message)
        {
        }
        public TradeBalanceBreachedException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
        public TradeBalanceBreachedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
