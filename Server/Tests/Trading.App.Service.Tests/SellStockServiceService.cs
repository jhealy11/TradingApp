using System;
using NUnit.Framework;
using Trading.App.Core.Trade.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Trading.App.Service.Tests
{
    [TestFixture]
    public class SellStockServiceService : BaseTest
    {
        private ISellStockService _sellStrockService = null;

        [SetUp]
        public void Setup()
        {
            IServiceProvider _serviceProvider = builder.Services.BuildServiceProvider();
            _sellStrockService = _serviceProvider.GetService<ISellStockService>();
        }

        [Test]
        public async Task PurchaseStock_WithGivenTrade_SavesStock()
        {
            var trade = new Core.Trade.Trade(Guid.NewGuid(), "MSFT", DateTime.Now, 50, 100, Core.Trade.ValueObject.TradeType.Sell);

            await _sellStrockService.SellStock(trade);
        }
    }
}
