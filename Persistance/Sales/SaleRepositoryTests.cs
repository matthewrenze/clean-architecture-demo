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
using CleanArchitecture.Common.Mocks;
using CleanArchitecture.Domain.Sales;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.Persistance.Sales
{
    [TestFixture]
    public class SaleRepositoryTests
    {
        [Test]
        public void TestConstructorShouldCreateRepository()
        {
            var context = new Mock<IDatabaseService>();
            var repository = new SaleRepository(context.Object);
            Assert.That(repository, Is.Not.Null);
        }
    }
}
