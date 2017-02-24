using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IDatabaseService
    {
        IRepository<Customer> Customers { get; }

        IRepository<Employee> Employees { get; }

        IRepository<Product> Products { get; }

        IRepository<Sale> Sales { get; }

        void Save();
    }
}