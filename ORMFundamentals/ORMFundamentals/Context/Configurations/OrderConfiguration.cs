using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ORMFundamentals.Models;

namespace ORMFundamentals.Context.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("dbo.Order");

            builder.HasKey(orderEntity => orderEntity.Id);

            builder.HasAlternateKey(o => o.ProductId);
        }
    }
}
