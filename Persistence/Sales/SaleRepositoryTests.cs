using CleanArchitecture.Persistence.Shared;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.Persistence.Sales
{
    [TestFixture]
    public class SaleRepositoryTests
    {
        [Test]
        public void TestConstructorShouldCreateRepository()
        {
            var context = new Mock<IDatabaseContext>();
            var repository = new SaleRepository(context.Object);
            Assert.That(repository, Is.Not.Null);
        }
    }
}
