using Microsoft.EntityFrameworkCore;
using WebStock.Models;

namespace WebStock.Data
{
    public class WebStockContext : DbContext
    {
        public WebStockContext(DbContextOptions<WebStockContext> options) : base (options){ }

        public DbSet<Adjustment> Adjustment { get; set; }
        public DbSet<AdjustmentReason> AdjustmentReason { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Entrie> Entrie { get; set; }
        public DbSet<EntryType> EntryType { get; set; }
        public DbSet<Exit> Exit { get; set; }
        public DbSet<ExitType> ExitType { get; set; }
        public DbSet<PriceHistory> PriceHistory { get; set; }
        public DbSet<Product> Product { get; set; }

    }
}
