using System;
using System.Collections.Generic;
using System.Linq;
using Moq.AutoMock;
using Moq.EntityFrameworkCore;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Customers;
using NUnit.Framework;

namespace CleanArchitecture.Application.Customers.Queries.GetCustomerList
{    
    [TestFixture]    
    public class GetCustomersListQueryTests
    {
        private GetCustomersListQuery _query;
        private AutoMocker _mocker;
        private Customer _customer;

        private const int Id = 1;
        private const string Name = "Customer 1";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMocker();

            _customer = new Customer()
            {
                Id = Id,
                Name = Name
            };

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Customers)
                .ReturnsDbSet(new List<Customer> { _customer });

            _query = _mocker.CreateInstance<GetCustomersListQuery>();
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
