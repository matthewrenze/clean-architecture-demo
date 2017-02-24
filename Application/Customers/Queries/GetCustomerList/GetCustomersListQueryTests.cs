using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Customers;
using NUnit.Framework;

namespace CleanArchitecture.Application.Customers.Queries.GetCustomerList
{
    [TestFixture]
    public class GetCustomersListQueryTests
    {
        private GetCustomersListQuery _query;
        private AutoMoqer _mocker;
        
        private const int Id = 1;
        private const string Name = "Customer 1";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            var customer = new Customer()
            {
                Id = Id,
                Name = Name
            };

            var customers = new List<Customer>
            {
                customer
            };

            _mocker.GetMock<IRepository<Customer>>()
                .Setup(p => p.GetAll())
                .Returns(customers.AsQueryable());

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Customers)
                .Returns(_mocker.GetMock<IRepository<Customer>>().Object);

            _query = _mocker.Create<GetCustomersListQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnListOfCustomers()
        {
            var results = _query.Execute();

            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.Name, Is.EqualTo(Name));
        }
    }
}
