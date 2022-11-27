using MartBerries_Server.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartBerries_Server.Infrastructure.Data
{
    public class ServerContext : DbContext
    {
        public ServerContext(DbContextOptions<ServerContext> options) : base(options) 
        {
            //Database.EnsureCreated();
        }

        public virtual DbSet<MoneyTransfer> MoneyTransfers { get; set; } = default!;
        public virtual DbSet<Order> Orders { get; set; } = default!;
        public virtual DbSet<OrderedProduct> OrderedProducts { get; set; } = default!;
        public virtual DbSet<Product> Products { get; set; } = default!;
        public virtual DbSet<ProductTransfer> ProductTransfers { get; set; } = default!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = default!;
        public virtual DbSet<SupplierProduct> SupplierProducts { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTransfer>()
                .HasOne(x => x.Product);
            modelBuilder.Entity<OrderedProduct>()
                .HasOne(x => x.Order)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.OrderId);
            modelBuilder.Entity<OrderedProduct>()
                .HasOne(x => x.Product)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<SupplierProduct>()
                .HasOne(x => x.Supplier)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SupplierProduct>()
                .HasOne(x => x.Product)
                .WithMany(x => x.Suppliers)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>()
                .HavePrecision(18, 6);
        }

        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
