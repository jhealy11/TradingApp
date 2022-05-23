namespace Trading.App.Core.Trade
{
    public class Trade
    {
        private readonly Guid _id;
        private readonly string _security;
        private readonly DateTime _tradeDate;
        private readonly decimal _price;
        private readonly int _quantity;
        private readonly ValueObject.TradeType _tradeType;
        private decimal _cashBalance;


        public Trade(Guid id, string security, DateTime tradeDate, decimal price, int quantity, ValueObject.TradeType tradeType)
        {
            _id = id;
            _security = security;
            _tradeDate = tradeDate;
            _price = price;
            _quantity = quantity;
            _tradeType = tradeType;
        }

        public Guid Id => _id;
        public string Security => _security;
        public DateTime TradeDate => _tradeDate;
        public decimal Price => _price;
        public int Quantity => _quantity;
        public ValueObject.TradeType TradeType => _tradeType;



        public decimal TradeTotal()
        {
            if (_tradeType == ValueObject.TradeType.Sell)
                return _quantity * _price;
            else
                return _quantity * _price * -1;
        }

        public bool CanSave()
        {

            if(_id == Guid.Empty)
                return false;

            if(string.IsNullOrEmpty(_security))
                return false;

            if(_tradeDate == DateTime.MinValue || _tradeDate > DateTime.MaxValue)
                return false;

            if(_price <= 0)
                return false;

            if (_quantity <= 0)
                return false;


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