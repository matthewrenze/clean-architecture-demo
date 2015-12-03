using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;
using CleanArchitecture.Domain.Vendors;

namespace CleanArchitecture.Persistance
{
    public class DatabaseInitializer 
        : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext database)
        {
            base.Seed(database);

            CreateCustomers(database);

            CreateEmployees(database);

            CreateVendors(database);

            CreateProducts(database);
            
            CreateSales(database);
        }

        private void CreateCustomers(DatabaseContext database)
        {
            database.Customers.Add(new Customer() { Name = "Martin Fowler" });

            database.Customers.Add(new Customer() { Name = "Uncle Bob" });

            database.Customers.Add(new Customer() { Name = "Jeff Palermo" });

            database.SaveChanges();
        }

        private void CreateEmployees(DatabaseContext database)
        {
            database.Employees.Add(new Employee() { Name = "Eric Evans" });

            database.Employees.Add(new Employee() { Name = "Greg Young" });

            database.Employees.Add(new Employee() { Name = "Udi Dahan" });

            database.SaveChanges();
        }

        private void CreateVendors(DatabaseContext database)
        {
            database.Vendors.Add(new Vendor() { Name = "Italian Foods, Inc." });

            database.Vendors.Add(new Vendor() { Name = "Sweet Treats, Inc." });

            database.SaveChanges();
        }

        private void CreateProducts(DatabaseContext database)
        {
            var vendors = database.Vendors.ToList();

            database.Products.Add(new Product() { Name = "Spaghetti", Vendor = vendors[0], Price = 5m });

            database.Products.Add(new Product() { Name = "Lasagna", Vendor = vendors[0], Price = 10m });

            database.Products.Add(new Product() { Name = "Ice Cream", Vendor = vendors[1], Price = 15m });

            database.Products.Add(new Product() { Name = "Cake", Vendor = vendors[1], Price = 20m });

            database.SaveChanges();
        }

        private void CreateSales(DatabaseContext database)
        {
            var customers = database.Customers.ToList();

            var employees = database.Employees.ToList();

            var products = database.Products.ToList();

            database.Sales.Add(new Sale()
            {
                DateTime = DateTime.Now.Date.AddDays(-2),
                Customer = customers[0],
                Employee = employees[0],
                Product = products[0],
                UnitPrice = 5m,
                Quantity = 4,
                TotalPrice = 20m
            });

            database.Sales.Add(new Sale()
            {
                DateTime = DateTime.Now.Date.AddDays(-2),
                Customer = customers[1],
                Employee = employees[1],
                Product = products[1],
                UnitPrice = 10m,
                Quantity = 3,
                TotalPrice = 30m
            });

            database.Sales.Add(new Sale()
            {
                DateTime = DateTime.Now.Date.AddDays(-1),
                Customer = customers[2],
                Employee = employees[2],
                Product = products[2],
                UnitPrice = 15m,
                Quantity = 2,
                TotalPrice = 30m
            });

            database.Sales.Add(new Sale()
            {
                DateTime = DateTime.Now.Date.AddDays(-1),
                Customer = customers[2],
                Employee = employees[2],
                Product = products[3],
                UnitPrice = 20m,
                Quantity = 1,
                TotalPrice = 20m
            });

            database.SaveChanges();
        }
    }
}
