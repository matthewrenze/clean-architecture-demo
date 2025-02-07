using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMoq;
using CleanArchitecture.Application.Customers.Queries.GetCustomerList;
using NUnit.Framework;

namespace CleanArchitecture.Service.Customers
{
    [TestFixture]
    public class CustomersControllerTests
    {
        private CustomersController _controller;
        private AutoMoqer _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _controller = _mocker.Create<CustomersController>();
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