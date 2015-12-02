using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;
using CleanArchitecture.Domain.Vendors;
using CleanArchitecture.Persistance.Customers;
using CleanArchitecture.Persistance.Employees;
using CleanArchitecture.Persistance.Products;
using CleanArchitecture.Persistance.Sales;
using CleanArchitecture.Persistance.Vendors;

namespace CleanArchitecture.Persistance
{
    public class Database : DbContext, IDatabase
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public Database() : base("CleanArchitecture")
        {
            
        }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new SaleConfiguration());
            modelBuilder.Configurations.Add(new SaleLineItemConfiguration());
            modelBuilder.Configurations.Add(new VendorConfiguration());
        }
    }
}
