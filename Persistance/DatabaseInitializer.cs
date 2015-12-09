using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;

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

            CreateProducts(database);
            
            CreateSales(database);
        }

        private void CreateCustomers(DatabaseContext database)
        {
            database.Customers.Add(new Customer() { Name = "Jeff Palermo" });

            database.Customers.Add(new Customer() { Name = "Martin Fowler" });

            database.Customers.Add(new Customer() { Name = "Uncle Bob" });

            database.SaveChanges();
        }

        private void CreateEmployees(DatabaseContext database)
        {
            database.Employees.Add(new Employee() { Name = "Eric Evans" });

            database.Employees.Add(new Employee() { Name = "Greg Young" });

            database.Employees.Add(new Employee() { Name = "Udi Dahan" });

            database.SaveChanges();
        }

        private void CreateProducts(DatabaseContext database)
        {
            database.Products.Add(new Product() { Name = "Cake", Price = 5m });

            database.Products.Add(new Product() { Name = "Ice Cream", Price = 10m });

            database.Products.Add(new Product() { Name = "Lasagna", Price = 15m });

            database.Products.Add(new Product() { Name = "Spaghetti", Price = 20m });

            database.SaveChanges();
        }

        private void CreateSales(DatabaseContext database)
        {
            var customers = database.Customers.ToList();

            var employees = database.Employees.ToList();

            var products = database.Products.ToList();

            database.Sales.Add(new Sale()
            {
                Date = DateTime.Now.Date.AddDays(-2),
                Customer = customers[0],
                Employee = employees[0],
                Product = products[0],
                UnitPrice = 5m,
                Quantity = 1,
                TotalPrice = 5m
            });

            database.Sales.Add(new Sale()
            {
                Date = DateTime.Now.Date.AddDays(-2),
                Customer = customers[1],
                Employee = employees[1],
                Product = products[1],
                UnitPrice = 10m,
                Quantity = 2,
                TotalPrice = 20m
            });

            database.Sales.Add(new Sale()
            {
                Date = DateTime.Now.Date.AddDays(-1),
                Customer = customers[2],
                Employee = employees[1],
                Product = products[2],
                UnitPrice = 15m,
                Quantity = 3,
                TotalPrice = 45m
            });

            database.Sales.Add(new Sale()
            {
                Date = DateTime.Now.Date.AddDays(-1),
                Customer = customers[2],
                Employee = employees[2],
                Product = products[3],
                UnitPrice = 20m,
                Quantity = 4,
                TotalPrice = 80m
            });

            database.SaveChanges();
        }
    }
}
