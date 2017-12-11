using CleanArchitecture.Persistence.Shared;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.Persistence.Customers
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
