using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Persistance.Shared;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.Persistance.Customers
{
    [TestFixture]
    public class CustomerRepositoryTests
    {
        [Test]
        public void TestConstructorShouldCreateRepository()
        {
            var context = new Mock<IDatabaseContext>();
            var repository = new CustomerRepository(context.Object);
            Assert.That(repository, Is.Not.Null);
        }
    }
}
