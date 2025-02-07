using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Customers
{
    public class CustomerConfiguration 
        : IEntityTypeConfiguration<Customer>
    {       

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new Customer() { Id = 1, Name = "Martin Fowler" },
                new Customer() { Id = 2, Name = "Uncle Bob" },
                new Customer() { Id = 3, Name = "Kent Beck" });
        }
    }
}
