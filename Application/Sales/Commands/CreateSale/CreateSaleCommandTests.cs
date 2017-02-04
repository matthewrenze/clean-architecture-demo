using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Application.Interfaces.Infrastructure;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Application.Sales.Commands.CreateSale.Factory;
using CleanArchitecture.Application.Sales.Commands.CreateSale.Repository;
using CleanArchitecture.Common.Dates;
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

            _mocker.GetMock<ISaleRepositoryFacade>()
                .Setup(p => p.GetCustomer(CustomerId))
                .Returns(customer);

            _mocker.GetMock<ISaleRepositoryFacade>()
                .Setup(p => p.GetEmployee(EmployeeId))
                .Returns(employee);

            _mocker.GetMock<ISaleRepositoryFacade>()
                .Setup(p => p.GetProduct(ProductId))
                .Returns(product);
                        
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

            _mocker.GetMock<ISaleRepositoryFacade>()
                .Verify(p => p.AddSale(_sale), 
                    Times.Once);
        }

        [Test]
        public void TestExecuteShouldSaveChangesToDatabase()
        {
            _command.Execute(_model);

            _mocker.GetMock<IUnitOfWork>()
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
    }
}
