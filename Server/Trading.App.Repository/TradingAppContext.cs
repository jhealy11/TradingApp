using Trading.App.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace Trading.App.Repository
{
    public sealed class TradingAppContext : DbContext
    {

        public TradingAppContext(DbContextOptions<TradingAppContext> options) : base(options)
        { 

        }

        public DbSet<Model.Trade> Trades { get; set; }
        public DbSet<CompanyBalance> CompanyBalances { get; set; }
        public DbSet<TradeType> TradeTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Trade>().ToTable("Trade");
            modelBuilder.Entity<CompanyBalance>().ToTable("CompanyBalance");
            modelBuilder.Entity<TradeType>().ToTable("TradeType");

        }
    }
}
