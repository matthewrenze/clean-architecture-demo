using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using NUnit.Framework;

namespace CleanArchitecture.Domain.Sales
{
    [TestFixture]
    public class SaleTests
    {
        private Sale _sale;
        private Customer _customer;
        private Employee _employee;
        private Product _product;

        private const int Id = 1;
        private static readonly DateTime Date = new DateTime(2001, 2, 3);
        private const decimal UnitPrice = 1.00m;
        private const int Quantity = 1;

        [SetUp]
        public void SetUp()
        {
            _customer = new Customer();

            _employee = new Employee();

            _product = new Product();

            _sale = new Sale();
        }

        [Test]
        public void TestSetAndGetId()
        {
            _sale.Id = Id;

            Assert.That(_sale.Id,
                Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetDate()
        {
            _sale.Date = Date;

            Assert.That(_sale.Date,
                Is.EqualTo(Date));
        }

        [Test]
        public void TestSetAndGetCustomer()
        {
            _sale.Customer = _customer;

            Assert.That(_sale.Customer,
                Is.EqualTo(_customer));
        }

        [Test]
        public void TestSetAndGetEmployee()
        {
            _sale.Employee = _employee;

            Assert.That(_sale.Employee,
                Is.EqualTo(_employee));
        }

        [Test]
        public void TestSetAndGetProduct()
        {
            _sale.Product = _product;

            Assert.That(_sale.Product,
                Is.EqualTo(_product));
        }

        [Test]
        public void TestSetAndGetUnitPrice()
        {
            _sale.UnitPrice = UnitPrice;

            Assert.That(_sale.UnitPrice, 
                Is.EqualTo(UnitPrice));
        }

        [Test]
        public void TestSetAndGetQuantity()
        {
            _sale.Quantity = Quantity;

            Assert.That(_sale.Quantity,
                Is.EqualTo(Quantity));
        }

        [Test]
        public void TestSetUnitPriceShouldRecomputeTotalPrice()
        {
            _sale.Quantity = Quantity;

            _sale.UnitPrice = 1.23m;

            Assert.That(_sale.TotalPrice, 
                Is.EqualTo(1.23m));
        }

        [Test]
        public void TestSetQuantityShouldRecomputeTotalPrice()
        {
            _sale.UnitPrice = UnitPrice;

            _sale.Quantity = 2;

            Assert.That(_sale.TotalPrice, 
                Is.EqualTo(2.00m));
        }
    }
}
