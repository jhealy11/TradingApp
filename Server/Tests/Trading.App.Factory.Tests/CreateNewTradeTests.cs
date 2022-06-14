using System;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using Trading.App.Core.Trade.Factory;

namespace Trading.App.Factory
{
    [TestFixture]
    public class CreateNewTradeTests : BaseTest
    {
        private ICreateNewTrade _createNewTrade = null;
        
        [OneTimeSetUp]
        public void Setup()
        {
            IServiceProvider _serviceProvider = builder.Services.BuildServiceProvider();
            _createNewTrade = _serviceProvider.GetService<ICreateNewTrade>();
        }

        [Test]
        public void CreateNewTrade_WithBuyTrade_CreatesNewBuyTrade()
        {
            const string security = "MSFT";
            DateTime tradeDate = DateTime.Now;
            const decimal price = 12m;
            const int quantity = 60000;
            const string tradeType = "Buy";

            var trade = _createNewTrade.CreateNewTrade(security, tradeDate, price, quantity, tradeType);

            Assert.AreEqual(Core.Trade.ValueObject.TradeType.Buy, trade.TradeType);
        }


        [Test]
        public void CreateNewTrade_WithBuyTrade_CreatesNewSellTrade()
        {
            const string security = "MSFT";
            DateTime tradeDate = DateTime.Now;
            const decimal price = 12m;
            const int quantity = 60000;
            const string tradeType = "Sell";

            var trade = _createNewTrade.CreateNewTrade(security, tradeDate, price, quantity, tradeType);

            Assert.AreEqual(Core.Trade.ValueObject.TradeType.Sell, trade.TradeType);
        }

        [Test]
        public void CreateNewTrade_WithInvalidTradeType_ThrowsException()
        {
            const string security = "MSFT";
            DateTime tradeDate = DateTime.Now;
            const decimal price = 12m;
            const int quantity = 60000;
            const string tradeType = "badType";

            Assert.Throws<Core.Trade.Exception.UnknownTradeTypeException> (() => _createNewTrade.CreateNewTrade(security, tradeDate, price, quantity, tradeType));

        }
    }
}
