using System;
using System.Collections.Generic;
using System.Linq;
using Moq.AutoMock;
using Moq.EntityFrameworkCore;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Products;
using NUnit.Framework;

namespace CleanArchitecture.Application.Products.Queries.GetProductsList
{
    [TestFixture]
    public class GetProductsListQueryTests
    {
        private GetProductsListQuery _query;
        private AutoMocker _mocker;
        private Product _product;

        private const int Id = 1;
        private const string Name = "Product 1";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMocker();

            _product = new Product()
            {
                Id = Id,
                Name = Name
            };

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Products)
                .ReturnsDbSet(new List<Product> { _product });

            _query = _mocker.CreateInstance<GetProductsListQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnListOfProducts()
        {
            var results = _query.Execute();

            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.Name, Is.EqualTo(Name));
        }
    }
}
