
using Microsoft.EntityFrameworkCore;
using Trading.App.Repository.Trade;
using Trading.App.Repository;
using Trading.App.Core.Trade.Repository;
using Trading.App.Core.Trade.Service;
using Trading.App.Service.Trade;
using Trading.App.Core.Trade.Factory;
using Trading.App.Factory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IPurchaseValidatorService, PurchaseValidatorService>();
builder.Services.AddScoped<IPurchaseStockService, PurchaseStockService>();
builder.Services.AddScoped<ISellStockService, SellStockService>();


builder.Services.AddScoped<ITradeRepository, TradeRepository>();
builder.Services.AddScoped<IPurchaseStockRepository, PurchaseStockRepository>();
builder.Services.AddScoped<IStockValidatorRepository, StockValidatorRepository>();

builder.Services.AddScoped<ISellStockRepository, SellStockRepository>();


builder.Services.AddScoped<ICreateNewTrade, CreateNewTrade>();

builder.Services.AddDbContext<TradingAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TradingAppContext")));

builder.Services.AddControllers();

builder.Services.AddHttpClient();


var app = builder.Build();

app.UseCors(x => x.AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowCredentials()); // allow credentials



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
