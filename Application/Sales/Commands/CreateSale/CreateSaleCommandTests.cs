using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Moq.AutoMock;
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
        private AutoMocker _mocker;
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

            _mocker = new AutoMocker();

            _mocker.GetMock<IDateService>()
                .Setup(p => p.GetDate())
                .Returns(Date);

            _mocker.GetMock<IRepository<Customer>>()
                .Setup(p => p.Get(CustomerId))
                .Returns(customer);

            _mocker.GetMock<IRepository<Employee>>()
                .Setup(p => p.Get(EmployeeId))
                .Returns(employee);

            _mocker.GetMock<IRepository<Product>>()
                .Setup(p => p.Get(ProductId))
                .Returns(product);

            _mocker.GetMock<IRepository<Sale>>()
                .Setup(p => p.GetAll())
                .Returns(new List<Sale>().AsQueryable());

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Customers)
                .Returns(_mocker.GetMock<IRepository<Customer>>().Object);

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Employees)
                .Returns(_mocker.GetMock<IRepository<Employee>>().Object);

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Products)
                .Returns(_mocker.GetMock<IRepository<Product>>().Object);

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Sales)
                .Returns(_mocker.GetMock<IRepository<Sale>>().Object);

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

            _mocker.GetMock<IRepository<Sale>>()
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
