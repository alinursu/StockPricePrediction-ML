using Microsoft.EntityFrameworkCore;

namespace MachineLearningModel
{
    public class StockDataContext : DbContext
    {
        public StockDataContext(DbContextOptions<StockDataContext> options) : base(options)
        {
        }

        public System.Data.Entity.DbSet<Stock> Stocks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().ToTable("Stocks");
        }
    }
}