using NUnit.Framework;
using Trading.App.Core.Trade.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Trading.App.Repository.Tests
{
    public class TradeRepositoryTests : BaseTest
    {

        private ITradeRepository _tradeRepository = null;

        [SetUp]
        public void Setup()
        {

            IServiceProvider _serviceProvider = builder.Services.BuildServiceProvider();
            _tradeRepository = _serviceProvider.GetService<ITradeRepository>();

            //_tradeRepository = builder.Services<TradeRepository>();
        }

        [Test]
        public void GetTrades()
        {

            var trades = _tradeRepository.GetTrades();

            Assert.IsNotNull(trades);
        }
    }
}