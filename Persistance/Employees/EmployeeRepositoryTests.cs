using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMoq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Interfaces.Persistence;
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
            var context = new Mock<IDatabaseService>();
            var repository = new EmployeeRepository(context.Object);
            Assert.That(repository, Is.Not.Null);
        }
    }
}
