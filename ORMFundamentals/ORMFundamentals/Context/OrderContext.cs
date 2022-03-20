using System;
using System.Collections.Generic;
using System.Text;
using ORMFundamentals.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ORMFundamentals.Context.Configurations;

namespace ORMFundamentals.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext()
        {
        }
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrderDB;Integrated Security=True;" +
                                            "Connect Timeout = 60; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            }
        }
    }
}
