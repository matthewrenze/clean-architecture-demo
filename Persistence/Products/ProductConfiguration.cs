using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Products
{
    public class ProductConfiguration
           : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(5, 2);

            builder.HasData(
                new Product() { Id = 1, Name = "Spaghetti", Price = 5m },
                new Product() { Id = 2, Name = "Lasagne", Price = 10m },
                new Product() { Id = 3, Name = "Ravioli", Price = 15m });
        }
    }
}
