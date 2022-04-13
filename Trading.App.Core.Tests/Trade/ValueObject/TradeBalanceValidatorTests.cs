using System;
using NUnit.Framework;
using Trading.App.Core.Trade.ValueObject;
namespace Trading.App.Core.Tests.Trade.ValueObject
{
    [TestFixture]
    public class TradeBalanceValidatorTests
    {
        private TradeBalanceValidator _validator;
        [OneTimeSetUp]
        public void Init()
        {
            _validator  = new TradeBalanceValidator();
        }

        [Test]
        public void IsTradeBalanceBreached_WithNotEnoughCash_IsBreached()
        {
            const decimal balance = 60m;
            var trade = new Core.Trade.Trade(new Guid(), "MSFT", DateTime.Now, 50, 5000, TradeType.Buy);
            
            
            var result = _validator.IsTradeBalanceBreached(trade, balance);


            Assert.IsTrue(result);
        }

        [Test]
        public void IsTradeBalanceBreached_WithEnoughCash_IsNotBreached()
        {
            const decimal balance = 600000000m;
            var trade = new Core.Trade.Trade(new Guid(), "MSFT", DateTime.Now, 50, 5000, TradeType.Buy);


            var result = _validator.IsTradeBalanceBreached(trade, balance);


            Assert.IsFalse(result);
        }
    }
}
