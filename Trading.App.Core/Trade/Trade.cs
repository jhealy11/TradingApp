﻿namespace Trading.App.Core.Trade
{
    public class Trade
    {
        private readonly Guid _id;
        private readonly string _secruity;
        private readonly DateTime _tradeDate;
        private readonly decimal _price;
        private readonly int _quantity;
        private readonly ValueObject.TradeType _tradeType;

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
            if (_tradeType.Description == "Sell")
                return _quantity * _price;
            else
                return _quantity * _price * -1;
        }

    }
}