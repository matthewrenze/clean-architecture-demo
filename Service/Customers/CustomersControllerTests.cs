using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moq.AutoMock;
using CleanArchitecture.Application.Customers.Queries.GetCustomerList;
using NUnit.Framework;

namespace CleanArchitecture.Service.Customers
{
    [TestFixture]
    public class CustomersControllerTests
    {
        private CustomersController _controller;
        private AutoMocker _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMocker();

            _controller = _mocker.CreateInstance<CustomersController>();
        }

        [Test]
        public void TestGetCustomersListShouldReturnListOfCustomers()
        {
            var customer = new CustomerModel();

            _mocker.GetMock<IGetCustomersListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<CustomerModel> { customer });

            var results = _controller.Get();

            Assert.That(results,
                Contains.Item(customer));
        }
    }
}