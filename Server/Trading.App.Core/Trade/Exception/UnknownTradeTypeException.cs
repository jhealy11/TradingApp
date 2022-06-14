using System.Runtime.Serialization;

namespace Trading.App.Core.Trade.Exception
{
    public class UnknownTradeTypeException : System.Exception
    {
        public UnknownTradeTypeException(string message)
            : base(message)
        {
        }
        public UnknownTradeTypeException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
        public UnknownTradeTypeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
