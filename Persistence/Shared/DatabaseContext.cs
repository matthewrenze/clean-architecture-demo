using System.Data.Entity;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;
using CleanArchitecture.Persistence.Customers;
using CleanArchitecture.Persistence.Employees;
using CleanArchitecture.Persistence.Products;
using CleanArchitecture.Persistence.Sales;

namespace CleanArchitecture.Persistence.Shared
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<Employee> Employees { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Sale> Sales { get; set; }

        public DatabaseContext() : base("CleanArchitecture")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public new IDbSet<T> Set<T>() where T : class, IEntity
        {
            return base.Set<T>();
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
        }
    }
}
