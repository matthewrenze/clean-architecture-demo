using CleanArchitecture.Persistence.Shared;
using Moq;
using NUnit.Framework;

namespace CleanArchitecture.Persistence.Employees
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
