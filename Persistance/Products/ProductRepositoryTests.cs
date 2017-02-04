using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Persistance.Shared;
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
            var context = new Mock<IDatabaseContext>();
            var repository = new ProductRepository(context.Object);
            Assert.That(repository, Is.Not.Null);
        }
    }
}
