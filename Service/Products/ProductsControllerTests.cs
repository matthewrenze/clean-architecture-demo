using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMoq;
using CleanArchitecture.Application.Products.Queries.GetProductsList;
using NUnit.Framework;

namespace CleanArchitecture.Service.Products
{
    [TestFixture]
    public class ProductsControllerTests
    {
        private ProductsController _controller;
        private AutoMoqer _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _controller = _mocker.Create<ProductsController>();
        }

        [Test]
        public void TestGetProductsListShouldReturnListOfProducts()
        {
            var product = new ProductModel();

            _mocker.GetMock<IGetProductsListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<ProductModel> { product });

            var results = _controller.Get();

            Assert.That(results,
                Contains.Item(product));
        }
    }
}