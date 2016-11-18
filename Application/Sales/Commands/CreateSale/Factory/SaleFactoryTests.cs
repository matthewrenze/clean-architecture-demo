using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using NUnit.Framework;

namespace CleanArchitecture.Application.Sales.Commands.CreateSale.Factory
{
    [TestFixture]
    public class SaleFactoryTests
    {
        private SaleFactory _factory;
        private Customer _customer = new Customer();
        private Employee _employee = new Employee();
        private Product _product = new Product();

        private static readonly DateTime DateTime = new DateTime(2001, 2, 3);
        private const int Quantity = 123;
        private const decimal Price = 1.00m;
        

        [SetUp]
        public void SetUp()
        {
            _customer = new Customer();

            _employee = new Employee();

            _product = new Product
            {
                Price = Price
            };

            _factory = new SaleFactory();
        }

        [Test]
        public void TestCreateShouldCreateSale()
        {
            var result = _factory.Create(DateTime, _customer, _employee, _product, Quantity);

            Assert.That(result.Date, Is.EqualTo(DateTime));
            Assert.That(result.Customer, Is.EqualTo(_customer));
            Assert.That(result.Employee, Is.EqualTo(_employee));
            Assert.That(result.Product, Is.EqualTo(_product));
            Assert.That(result.UnitPrice, Is.EqualTo(Price));
            Assert.That(result.Quantity, Is.EqualTo(Quantity));
        }

    }
}
