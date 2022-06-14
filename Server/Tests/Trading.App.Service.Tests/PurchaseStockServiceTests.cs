using NUnit.Framework;
using Trading.App.Core.Trade.Service;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Trading.App.Service.Tests
{
    [TestFixture]
    public class PurchaseStockServiceTests : BaseTest
    {
        private IPurchaseStockService _purchaseStrockService = null;

        [OneTimeSetUp]
        public void Setup()
        {
            IServiceProvider _serviceProvider = builder.Services.BuildServiceProvider();
            _purchaseStrockService = _serviceProvider.GetService<IPurchaseStockService>();
        }

        [Test]
        public async Task PurchaseStock_WithGivenTrade_SavesStock()
        {
            var trade = new Core.Trade.Trade(Guid.NewGuid(), "MSFT", DateTime.Now, 50, 100, Core.Trade.ValueObject.TradeType.Buy);

            await _purchaseStrockService.PurchaseStock(trade);
        }
    }
}