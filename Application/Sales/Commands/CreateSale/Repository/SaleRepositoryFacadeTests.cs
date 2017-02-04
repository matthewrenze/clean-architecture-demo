using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.Application.Sales.Commands.CreateSale.Repository
{
    [TestFixture]
    public class SaleRepositoryFacadeTests
    {
        private SaleRepositoryFacade _facade;
        private AutoMoqer _mocker;
        private Customer _customer;
        private Employee _employee;
        private Product _product;
        private Sale _sale;

        private const int CustomerId = 1;
        private const int EmployeeId = 2;
        private const int ProductId = 3;
        private const int SaleId = 4;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _customer = new Customer();

            _employee = new Employee();

            _product = new Product();

            _sale = new Sale();

            _facade = _mocker.Create<SaleRepositoryFacade>();
        }

        [Test]
        public void TestGetCustomerShouldReturnCustomer()
        {
            _mocker.GetMock<ICustomerRepository>()
                .Setup(p => p.Get(CustomerId))
                .Returns(_customer);

            var result = _facade.GetCustomer(CustomerId);

            Assert.That(result, 
                Is.EqualTo(_customer));
        }

        [Test]
        public void TestGetEmployeeShouldReturnEmployee()
        {
            _mocker.GetMock<IEmployeeRepository>()
                .Setup(p => p.Get(EmployeeId))
                .Returns(_employee);

            var result = _facade.GetEmployee(EmployeeId);

            Assert.That(result,
                Is.EqualTo(_employee));
        }

        [Test]
        public void TestGetProductShouldReturnProduct()
        {
            _mocker.GetMock<IProductRepository>()
                .Setup(p => p.Get(ProductId))
                .Returns(_product);

            var result = _facade.GetProduct(ProductId);

            Assert.That(result,
                Is.EqualTo(_product));
        }

        [Test]
        public void TestAddSaleShouldAddSale()
        {
            _facade.AddSale(_sale);

            _mocker.GetMock<ISaleRepository>()
                .Verify(p => p.Add(_sale),
                    Times.Once);
        }
    }
}
