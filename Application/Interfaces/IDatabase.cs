using System.Data.Entity;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;
using CleanArchitecture.Domain.Vendors;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IDatabase
    {
        DbSet<Customer> Customers { get; set; }

        DbSet<Employee> Employees { get; set; }
        
        DbSet<Product> Products { get; set; }
        
        DbSet<Sale> Sales { get; set; }
        
        DbSet<Vendor> Vendors { get; set; }

        void Save();
    }
}