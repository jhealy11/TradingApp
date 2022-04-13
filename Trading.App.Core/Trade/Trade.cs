namespace Trading.App.Core.Trade
{
    public class Trade
    {
        private readonly Guid _id;
        private readonly string _secruity;
        private readonly DateTime _tradeDate;
        private readonly decimal _price;
        private readonly int _quantity;
        private readonly ValueObject.TradeType _tradeType;
        private decimal _cashBalance;


        public Trade(Guid id, string secruity, DateTime tradeDate, decimal price, int quantity, ValueObject.TradeType tradeType)
        {
            _id = id;
            _secruity = secruity;
            _tradeDate = tradeDate;
            _price = price;
            _quantity = quantity;
            _tradeType = tradeType;
        }


        public decimal TradeTotal()
        {
            if (_tradeType == ValueObject.TradeType.Sell)
                return _quantity * _price;
            else
                return _quantity * _price * -1;
        }

        public bool CanSave()
        {

            return true;

        }

        public void SetNewCashBalance(decimal existingCashBalance)
        {
            _cashBalance = existingCashBalance + TradeTotal();
        }

        public decimal GetCashBalance()
        {
            return _cashBalance;
        }
    }
}