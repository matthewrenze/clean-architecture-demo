using System;
using System.Collections.Generic;
using System.Linq;
using Moq.AutoMock;
using CleanArchitecture.Application.Products.Queries.GetProductsList;
using NUnit.Framework;

namespace CleanArchitecture.Presentation.Products
{
    [TestFixture]
    public class ProductsControllerTests
    {
        private ProductsController _controller;
        private AutoMocker _mocker;
        private ProductModel _model;

        [SetUp]
        public void SetUp()
        {
            _model = new ProductModel();

            _mocker = new AutoMocker();

            _mocker.GetMock<IGetProductsListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<ProductModel> { _model });

            _controller = _mocker.CreateInstance<ProductsController>();
        }

        [Test]
        public void TestGetIndexShouldReturnListOfProducts()
        {
            var viewResult = _controller.Index();

            var result = (List<ProductModel>)viewResult.Model;

            Assert.That(result.Single(), Is.EqualTo(_model));
        }
    }
}