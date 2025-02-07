using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<Customer> Customers { get; set; }

        DbSet<Employee> Employees { get; set; }
        
        DbSet<Product> Products { get; set; }
        
        DbSet<Sale> Sales { get; set; }

        void Save();
    }
}