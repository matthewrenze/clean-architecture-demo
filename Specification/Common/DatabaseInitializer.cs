using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;
using Moq;

namespace CleanArchitecture.Specification.Common
{
    public class DatabaseInitializer
    {
        private readonly Mock<IDatabaseService> _mockDatabase;
        
        public DatabaseInitializer(Mock<IDatabaseService> mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public void Seed()
        {
            CreateCustomers();

            CreateEmployees();

            CreateProducts();

            CreateSales();
        }

        private void CreateCustomers()
        {
            var customers = new InMemoryDbSet<Customer>();

            CreateCustomer(customers, 1, "Martin Fowler");

            CreateCustomer(customers, 2, "Uncle Bob");

            CreateCustomer(customers, 3, "Kent Beck");

            _mockDatabase.Setup(p => p.Customers)
                .Returns(customers);
        }

        private void CreateCustomer(IDbSet<Customer> customers, int id, string name)
        {
            var customer = new Customer
            {
                Id = id,
                Name = name
            };

            customers.Add(customer);
        }

        private void CreateEmployees()
        {
            var employees = new InMemoryDbSet<Employee>();

            CreateEmployee(employees, 1, "Eric Evans");

            CreateEmployee(employees, 2, "Greg Young");

            CreateEmployee(employees, 3, "Udi Dahan");

            _mockDatabase.Setup(p => p.Employees)
                .Returns(employees);
        }

        private void CreateEmployee(IDbSet<Employee> employees , int id, string name)
        {
            var employee = new Employee
            {
                Id = id,
                Name = name
            };

            employees.Add(employee);
        }

        private void CreateProducts()
        {
            var products = new InMemoryDbSet<Product>();

            CreateProduct(products, 1, "Spaghetti", 5m);

            CreateProduct(products, 2, "Lasagne", 10m);

            CreateProduct(products, 3, "Ravioli", 15m);

            _mockDatabase.Setup(p => p.Products)
                .Returns(products);
        }

        private void CreateProduct(IDbSet<Product> products, int id, string name, decimal price)
        {
            var product = new Product
            {
                Id = id,
                Name = name,
                Price = price
            };

            products.Add(product);
        }

        private void CreateSales()
        {
            var sales = new InMemoryDbSet<Sale>();

            CreateSale(sales, 1, 0, 1, 1, 1, 1);

            CreateSale(sales, 2, 1, 2, 2, 2, 2);

            CreateSale(sales, 3, 2, 3, 3, 3, 3);

            _mockDatabase.Setup(p => p.Sales)
                .Returns(sales);
        }

        private void CreateSale(
            IDbSet<Sale> sales,
            int id,
            int dateOffset,
            int customerId, 
            int employeeId, 
            int productId,
            int quantity)
        {

            var date = new DateTime(2001, 2, 3);

            var customer = _mockDatabase.Object.Customers
                .Single(p => p.Id == customerId);

            var employee = _mockDatabase.Object.Employees
                .Single(p => p.Id == employeeId);

            var product = _mockDatabase.Object.Products
                .Single(p => p.Id == productId);

            var sale = new Sale()
            {
                Id = id,
                Date = date.AddDays(dateOffset),
                Customer = customer,
                Employee = employee,
                Product = product,
                UnitPrice = product.Price,
                Quantity = quantity
            };

            sales.Add(sale);
        }
    }
}
