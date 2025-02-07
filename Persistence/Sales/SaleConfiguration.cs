using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Sales
{
    public class SaleConfiguration
           : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Date)
                .IsRequired();

            builder.HasOne(p => p.Customer);

            builder.Navigation(p => p.Customer)
                .IsRequired()
                .AutoInclude();

            builder.HasOne(p => p.Employee);

            builder.Navigation(p => p.Employee)
                .IsRequired()
                .AutoInclude();

            builder.HasOne(p => p.Product);

            builder.Navigation(p => p.Product)
                .IsRequired()
                .AutoInclude();

            builder.Property(p => p.TotalPrice)
                .IsRequired()
                .HasPrecision(5, 2);

            // Note: Uses anonomous types to seed foreign keys
            builder.HasData(
                new
                {
                    Id = 1,
                    Date = DateTime.Parse("2022-01-01"),
                    CustomerId = 1,
                    EmployeeId = 1,
                    ProductId = 1,
                    UnitPrice = 5m,
                    Quantity = 1,
                    TotalPrice = 5m
                },
                new
                {
                    Id = 2,
                    Date = DateTime.Parse("2022-01-02"),
                    CustomerId = 2,
                    EmployeeId = 2,
                    ProductId = 2,
                    UnitPrice = 10m,
                    Quantity = 2,
                    TotalPrice = 20m
                },
                new
                {
                    Id = 3,
                    Date = DateTime.Parse("2022-01-03"),
                    CustomerId = 3,
                    EmployeeId = 3,
                    ProductId = 3,
                    UnitPrice = 15m,
                    Quantity = 3,
                    TotalPrice = 45m
                });
        }
    }
}
