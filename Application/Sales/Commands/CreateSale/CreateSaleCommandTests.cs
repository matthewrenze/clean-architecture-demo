using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Moq.AutoMock;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Sales.Commands.CreateSale.Factory;
using CleanArchitecture.Common.Dates;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;

namespace CleanArchitecture.Application.Sales.Commands.CreateSale
{
    [TestFixture]
    public class CreateSaleCommandTests
    {
        private CreateSaleCommand _command;
        private AutoMocker _mocker;
        private CreateSaleModel _model;
        private Sale _sale;

        private static readonly DateTime Date = new(2001, 2, 3);
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
            
            _mocker = new AutoMocker();

            _mocker.GetMock<IDateService>()
                .Setup(p => p.GetDate())
                .Returns(Date);

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Customers)
                .ReturnsDbSet(new List<Customer> { customer });

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Employees)
                .ReturnsDbSet(new List<Employee> { employee });

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Products)
                .ReturnsDbSet(new List<Product> { product });

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Sales)
                .Returns(_mocker.GetMock<DbSet<Sale>>().Object);

            _mocker.GetMock<ISaleFactory>()
                .Setup(p => p.Create(
                    Date,
                    customer,
                    employee,
                    product,
                    Quantity))
                .Returns(_sale);
            
            _command = _mocker.CreateInstance<CreateSaleCommand>();
        }

        [Test]
        public void TestExecuteShouldAddSaleToTheDatabase()
        {
            _command.Execute(_model);

            _mocker.GetMock<DbSet<Sale>>()
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
                .Verify(p => p.NotifySaleOccurred(
                        ProductId,
                        Quantity),
                    Times.Once);
        }
    }
}
