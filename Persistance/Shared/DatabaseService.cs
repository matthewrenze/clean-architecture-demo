using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;

namespace CleanArchitecture.Persistance.Shared
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IDatabaseContext _context;
        private readonly RepositoryAdapter<Customer> _customers;
        private readonly RepositoryAdapter<Employee> _employees;
        private readonly RepositoryAdapter<Product> _products;
        private readonly RepositoryAdapter<Sale> _sales;

        public DatabaseService(IDatabaseContext context)
        {
            _context = context;

            _customers = new RepositoryAdapter<Customer>(_context.Customers);

            _employees = new RepositoryAdapter<Employee>(_context.Employees);

            _products = new RepositoryAdapter<Product>(_context.Products);

            _sales = new RepositoryAdapter<Sale>(_context.Sales);
        }

        public IRepository<Customer> Customers
        {
            get { return _customers; }
        }

        public IRepository<Employee> Employees
        {
            get { return _employees; }
        }

        public IRepository<Product> Products
        {
            get { return _products; }
        }

        public IRepository<Sale> Sales
        {
            get { return _sales; }
        }

        public void Save()
        {
            _context.Save();
        }
    }
}
