using System.Data.Entity;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;

namespace CleanArchitecture.Persistence.Shared
{
    public interface IDatabaseContext
    {
        IDbSet<Customer> Customers { get; set; }

        IDbSet<Employee> Employees { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<Sale> Sales { get; set; }

        void Save();
    }
}