using Microsoft.EntityFrameworkCore;

namespace WebScraperApp.Models
{
    public class StockContext : DbContext
    {
        public StockContext (DbContextOptions<StockContext> options)
        : base(options)
        {

        }
        public DbSet<WebScraperApp.Models.StockItem> StockItem { get; set; }
    }
}