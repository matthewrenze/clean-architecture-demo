using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMoq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Sales.Commands.CreateSale.Factory;
using CleanArchitecture.Common.Dates;
using CleanArchitecture.Common.Mocks;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.Application.Sales.Commands.CreateSale
{
    [TestFixture]
    public class CreateSaleCommandTests
    {
        private CreateSaleCommand _command;
        private AutoMoqer _mocker;
        private CreateSaleModel _model;
        private Sale _sale;

        private static readonly DateTime Date = new DateTime(2001, 2, 3);
        private const int CustomerId = 1;
        private const int EmployeeId = 2;
        private const int ProductId = 3;
        private const decimal UnitPrice = 1.23m;
        private const int Quantity = 4;

        [SetUp]
        public void SetUp()
        {
            var customer = new Customer
            {
                Id = CustomerId
            };

            var employee = new Employee
            {
                Id = EmployeeId
            };

            var product = new Product
            {
                Id = ProductId,
                Price = UnitPrice
            };

            _model = new CreateSaleModel()
            {
                CustomerId = CustomerId,
                EmployeeId = EmployeeId,
                ProductId = ProductId,
                Quantity = Quantity
            };

            _sale = new Sale();
            
            _mocker = new AutoMoqer();

            _mocker.GetMock<IDateService>()
                .Setup(p => p.GetDate())
                .Returns(Date);

            SetUpDbSet(p => p.Customers, customer);
            SetUpDbSet(p => p.Employees, employee);
            SetUpDbSet(p => p.Products, product);
            SetUpDbSet(p => p.Sales);

            _mocker.GetMock<ISaleFactory>()
                .Setup(p => p.Create(
                    Date,
                    customer,
                    employee,
                    product,
                    Quantity))
                .Returns(_sale);
            
            _command = _mocker.Create<CreateSaleCommand>();
        }

        [Test]
        public void TestExecuteShouldAddSaleToTheDatabase()
        {
            _command.Execute(_model);

            _mocker.GetMock<IDbSet<Sale>>()
                .Verify(p => p.Add(_sale),
                    Times.Once);
        }

        [Test]
        public void TestExecuteShouldSaveChangesToDatabase()
        {
            _command.Execute(_model);

            _mocker.GetMock<IDatabaseService>()
                .Verify(p => p.Save(),
                    Times.Once);
        }

        [Test]
        public void TestExecuteShouldNotifyInventoryThatSaleOccurred()
        {
            _command.Execute(_model);

            _mocker.GetMock<IInventoryService>()
                .Verify(p => p.NotifySaleOcurred(
                        ProductId,
                        Quantity),
                    Times.Once);
        }

        private void SetUpDbSet<T>(Expression<Func<IDatabaseService, IDbSet<T>>> property, T entity)
            where T : class
        {
            _mocker.GetMock<IDbSet<T>>()
               .SetUpDbSet(new List<T> { entity });

            _mocker.GetMock<IDatabaseService>()
               .Setup(property)
               .Returns(_mocker.GetMock<IDbSet<T>>().Object);
        }

        private void SetUpDbSet<T>(Expression<Func<IDatabaseService, IDbSet<T>>> property)
           where T : class
        {
            _mocker.GetMock<IDbSet<T>>()
               .SetUpDbSet(new List<T>());

            _mocker.GetMock<IDatabaseService>()
               .Setup(property)
               .Returns(_mocker.GetMock<IDbSet<T>>().Object);
        }
    }
}
