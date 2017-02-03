using System.Data.Entity;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;

namespace CleanArchitecture.Persistance.Shared
{
    public interface IDatabaseContext
    {
        IDbSet<Customer> Customers { get; set; }

        IDbSet<Employee> Employees { get; set; }
        
        IDbSet<Product> Products { get; set; }
        
        IDbSet<Sale> Sales { get; set; }

        IDbSet<T> Set<T>() where T : class, IEntity;

        void Save();
    }
}