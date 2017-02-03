using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMoq;
using CleanArchitecture.Application.Interfaces;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.Persistance.Products
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        [Test]
        public void TestConstructorShouldCreateRepository()
        {
            var context = new Mock<IDatabaseService>();
            var repository = new ProductRepository(context.Object);
            Assert.That(repository, Is.Not.Null);
        }
    }
}
