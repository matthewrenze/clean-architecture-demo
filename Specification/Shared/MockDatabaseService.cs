using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;
using CleanArchitecture.Persistence.Customers;
using CleanArchitecture.Persistence.Employees;
using CleanArchitecture.Persistence.Products;
using CleanArchitecture.Persistence.Sales;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Specification.Shared
{
    public class MockDatabaseService : DbContext, IDatabaseService
    {
        public MockDatabaseService(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CleanArchitectureInMemory");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new CustomerConfiguration().Configure(builder.Entity<Customer>());
            new EmployeeConfiguration().Configure(builder.Entity<Employee>());
            new ProductConfiguration().Configure(builder.Entity<Product>());
            new SaleConfiguration().Configure(builder.Entity<Sale>());
        }
    }
}
