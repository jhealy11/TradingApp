using Trading.App.Validator;
using Microsoft.EntityFrameworkCore;
using Trading.App.Repository.Trade;
using Trading.App.Repository;
using Trading.App.Core.Trade.Repository;
using Trading.App.Core.Trade.Service;
using Trading.App.Service.Trade;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IPurchaseValidator, PurchaseValidator>();
builder.Services.AddScoped<ITradeRepository, TradeRepository>();
builder.Services.AddScoped<IPurchaseStockRepository, PurchaseStockRepository>();
builder.Services.AddScoped<IPurchaseStockService, PurchaseStockService>();
builder.Services.AddDbContext<TradingAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TradingAppContext")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<TradingAppContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}


app.UseHttpsRedirection();
app.MapControllers();





app.Run();
