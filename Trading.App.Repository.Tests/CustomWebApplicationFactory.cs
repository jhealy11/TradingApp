using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Trading.App.Repository.Tests
{
    public class BaseTest
    {

        protected WebApplicationBuilder builder = null;
        protected BaseTest()
        {

            builder = WebApplication.CreateBuilder();


            builder.Services.AddScoped<Core.Trade.Repository.ITradeRepository, Repository.Trade.TradeRepository>();
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
