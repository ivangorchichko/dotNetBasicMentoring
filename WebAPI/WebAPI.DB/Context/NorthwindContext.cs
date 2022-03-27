using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebAPI.DB.Models;

namespace WebAPI.DB.Context
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Products");
                e.HasKey(product => product.ProductId);
                e.HasOne(c => c.Category)
                    .WithMany()
                    .IsRequired();
                e.HasOne(c => c.Supplier)
                    .WithMany()
                    .IsRequired();
            });

            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Categories");
                e.HasKey(category => category.CategoryId);
            });

            modelBuilder.Entity<Supplier>(e =>
            {
                e.ToTable("Suppliers");
                e.HasKey(supplier => supplier.SupplierId);
            });
        }
    }
}
