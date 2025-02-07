using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Employees
{
    public class EmployeeConfiguration
           : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new Employee() { Id = 1, Name = "Eric Evans" },
                new Employee() { Id = 2, Name = "Greg Young" },
                new Employee() { Id = 3, Name = "Udi Dahan" });
        }
    }
}
