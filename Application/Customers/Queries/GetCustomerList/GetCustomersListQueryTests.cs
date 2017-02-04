using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Customers;
using NUnit.Framework;

namespace CleanArchitecture.Application.Customers.Queries.GetCustomerList
{
    [TestFixture]
    public class GetCustomersListQueryTests
    {
        private GetCustomersListQuery _query;
        private AutoMoqer _mocker;
        private List<Customer> _customers;
        private Customer _customer;

        private const int Id = 1;
        private const string Name = "Customer 1";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _customer = new Customer()
            {
                Id = Id,
                Name = Name
            };

            _customers = new List<Customer>()
            {
                _customer
            };

            _mocker.GetMock<ICustomerRepository>()
                .Setup(p => p.GetAll())
                .Returns(_customers.AsQueryable());

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
