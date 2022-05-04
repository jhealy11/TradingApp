using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Trading.App.Repository;

namespace Trading.App.Service.Tests
{
    public class BaseTest
    {
        protected WebApplicationBuilder builder = null;
        protected BaseTest()
        {

            builder = WebApplication.CreateBuilder();


            builder.Services.AddScoped<Core.Trade.Repository.ITradeRepository, Repository.Trade.TradeRepository>();
            builder.Services.AddScoped<Core.Trade.Service.IPurchaseStockService, Service.Trade.PurchaseStockService>();
            builder.Services.AddScoped<Core.Trade.Service.IPurchaseValidatorService, Service.Trade.PurchaseValidatorService>();
            builder.Services.AddScoped<Core.Trade.Repository.IPurchaseStockRepository, Repository.Trade.PurchaseStockRepository>();
            builder.Services.AddScoped<Core.Trade.Repository.IStockValidatorRepository, Repository.Trade.StockValidatorRepository>();
            builder.Services.AddScoped<Core.Trade.Service.ISellStockService, Service.Trade.SellStockService>();
            builder.Services.AddScoped<Core.Trade.Repository.ISellStockRepository, Repository.Trade.SellStockRepository>();


            builder.Services.AddDbContext<TradingAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TradingAppContext")));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<TradingAppContext>();
                context.Database.EnsureCreated();
                // DbInitializer.Initialize(context);
            }
        }
    }
}
