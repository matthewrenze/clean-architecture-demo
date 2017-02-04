using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;

namespace CleanArchitecture.Application.Sales.Commands.CreateSale.Repository
{
    public class SaleRepositoryFacade : ISaleRepositoryFacade
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISaleRepository _saleRepository;

        public SaleRepositoryFacade(
            ICustomerRepository customerRepository,
            IEmployeeRepository employeeRepository,
            IProductRepository productRepository,
            ISaleRepository saleRepository)
        {
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;
            _saleRepository = saleRepository;
        }

        public Customer GetCustomer(int customerId)
        {
            return _customerRepository.Get(customerId);
        }

        public Employee GetEmployee(int employeeId)
        {
            return _employeeRepository.Get(employeeId);
        }

        public Product GetProduct(int productId)
        {
            return _productRepository.Get(productId);
        }

        public void AddSale(Sale sale)
        {
            _saleRepository.Add(sale);
        }
    }


}
