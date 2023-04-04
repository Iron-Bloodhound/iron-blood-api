using ironblood.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace ironblood.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        { }

        public DbSet<Item> Items {get; set;}
    }
}