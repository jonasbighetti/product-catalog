using Microsoft.EntityFrameworkCore;
using ProductCatalog.API.Data.Maps;
using ProductCatalog.API.Models;

namespace ProductCatalog.API.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public StoreDataContext(DbContextOptions<StoreDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
        }
    }
}