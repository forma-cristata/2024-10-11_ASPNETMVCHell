using Inventory.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.DbContexts
{
    public class InventoryDBContext : DbContext
    {
        public InventoryDBContext(DbContextOptions<InventoryDBContext> options) : base(options) { }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(k => k.ProductId).HasName("PRIMARY");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(k => k.StoreId).HasName("PRIMARY");
            });
        }
    }
}
