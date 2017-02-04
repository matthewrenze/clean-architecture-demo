using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Persistance.Shared;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.Persistance.Employees
{
    [TestFixture]
    public class EmployeeRepositoryTests
    {
        [Test]
        public void TestConstructorShouldCreateRepository()
        {
            var context = new Mock<IDatabaseContext>();
            var repository = new EmployeeRepository(context.Object);
            Assert.That(repository, Is.Not.Null);
        }
    }
}
