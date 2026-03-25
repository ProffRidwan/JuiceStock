using JuiceStock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JuiceStock.Infrastructure.Persistence
{
    public class JuiceStockDbContext : DbContext
    {
        public JuiceStockDbContext(DbContextOptions<JuiceStockDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LedgerEntry>(entity =>
            {
                entity.Property(x => x.Amount)
                      .HasPrecision(18, 2); // ₦, $, accounting-safe
            });
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}