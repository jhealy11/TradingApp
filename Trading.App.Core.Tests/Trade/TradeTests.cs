using NUnit.Framework;
using Trading.App.Core.Trade;
namespace Trading.App.Core.Tests
{
    [TestFixture]
    public class TradeTests
    {
        [Test]
        public void TradeTotal_WithSellTrade_ReturnsPositiveTradeTotal()
        {
            const decimal total = 2250000m;

            Core.Trade.Trade trade = new Core.Trade.Trade(new System.Guid(), "MSFT", System.DateTime.Now, 45, 50000, Core.Trade.ValueObject.TradeType.Sell);

            var result = trade.TradeTotal();

            Assert.AreEqual(total, result);
        }

        [Test]
        public void TradeTotal_WithBuyTrade_ReturnsNegativeTradeTotal()
        {
            const decimal total = -2250000m;

            Core.Trade.Trade trade = new Core.Trade.Trade(new System.Guid(), "MSFT", System.DateTime.Now, 45, 50000, Core.Trade.ValueObject.TradeType.Buy);

            var result = trade.TradeTotal();

            Assert.AreEqual(total, result);
        }

        [Test]
        public void CanSave_WithInvalidGuid_ReturnsFalse()
        {
            Core.Trade.Trade trade = new Core.Trade.Trade(System.Guid.Empty, "MSFT", System.DateTime.Now, 45, 50000, Core.Trade.ValueObject.TradeType.Buy);


            var result = trade.CanSave();

            Assert.IsFalse(result);
        }

        [Test]
        public void CanSave_WithNullSecurity_ReturnsFalse()
        {
            Core.Trade.Trade trade = new Core.Trade.Trade(new System.Guid(), null, System.DateTime.Now, 45, 50000, Core.Trade.ValueObject.TradeType.Buy);


            var result = trade.CanSave();

            Assert.IsFalse(result);
        }

        [Test]
        public void CanSave_WithMinDate_ReturnsFalse()
        {
            Core.Trade.Trade trade = new Core.Trade.Trade(new System.Guid(), "MSFT", System.DateTime.MinValue, 45, 50000, Core.Trade.ValueObject.TradeType.Buy);


            var result = trade.CanSave();

            Assert.IsFalse(result);
        }

        [Test]
        public void CanSave_WithMaxDate_ReturnsFalse()
        {
            Core.Trade.Trade trade = new Core.Trade.Trade(new System.Guid(), "MSFT", System.DateTime.MaxValue, 45, 50000, Core.Trade.ValueObject.TradeType.Buy);


            var result = trade.CanSave();

            Assert.IsFalse(result);
        }

        [Test]
        public void CanSave_WithNegativePrice_ReturnsFalse()
        {
            Core.Trade.Trade trade = new Core.Trade.Trade(new System.Guid(), "MSFT", System.DateTime.Now, -45, 50000, Core.Trade.ValueObject.TradeType.Buy);


            var result = trade.CanSave();

            Assert.IsFalse(result);
        }

        [Test]
        public void CanSave_WithNegativeQuantity_ReturnsFalse()
        {
            Core.Trade.Trade trade = new Core.Trade.Trade(new System.Guid(), "MSFT", System.DateTime.Now, 45, -50000, Core.Trade.ValueObject.TradeType.Buy);


            var result = trade.CanSave();

            Assert.IsFalse(result);
        }
    }
}
