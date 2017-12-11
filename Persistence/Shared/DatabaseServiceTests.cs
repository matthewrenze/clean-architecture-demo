using AutoMoq;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;
using NUnit.Framework;

namespace CleanArchitecture.Persistence.Shared
{
    [TestFixture]
    public class DatabaseServiceTests
    {
        private DatabaseService _service;
        private AutoMoqer _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _service = _mocker.Create<DatabaseService>();
        }

        [Test]
        public void TestGetCustomersShouldReturnAdaptedCustomers()
        {
            var result = _service.Customers;

            Assert.That(result,
                Is.TypeOf<RepositoryAdapter<Customer>>());
        }

        [Test]
        public void TestGetEmployeesShouldReturnAdaptedEmployees()
        {
            var result = _service.Employees;

            Assert.That(result,
                Is.TypeOf<RepositoryAdapter<Employee>>());
        }

        [Test]
        public void TestGetProductsShouldReturnAdaptedProducts()
        {
            var result = _service.Products;

            Assert.That(result,
                Is.TypeOf<RepositoryAdapter<Product>>());
        }

        [Test]
        public void TestGetSalesShouldReturnAdaptedSales()
        {
            var result = _service.Sales;

            Assert.That(result,
                Is.TypeOf<RepositoryAdapter<Sale>>());
        }
    }
}
