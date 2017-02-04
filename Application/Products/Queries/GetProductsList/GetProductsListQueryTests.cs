using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Products;
using NUnit.Framework;

namespace CleanArchitecture.Application.Products.Queries.GetProductsList
{
    [TestFixture]
    public class GetProductsListQueryTests
    {
        private GetProductsListQuery _query;
        private AutoMoqer _mocker;
        private List<Product> _products;
        private Product _product;

        private const int Id = 1;
        private const string Name = "Product 1";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _product = new Product()
            {
                Id = Id,
                Name = Name
            };

            _products = new List<Product>()
            {
                _product
            };

            _mocker.GetMock<IProductRepository>()
                .Setup(p => p.GetAll())
                .Returns(_products.AsQueryable());

            _query = _mocker.Create<GetProductsListQuery>();
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
