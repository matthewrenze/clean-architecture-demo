using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using CleanArchitecture.Application.Sales.Commands.CreateSale;
using CleanArchitecture.Application.Sales.Queries.GetSaleDetail;
using CleanArchitecture.Application.Sales.Queries.GetSalesList;
using CleanArchitecture.Presentation.Sales.Models;
using CleanArchitecture.Presentation.Sales.Services;
using NUnit.Framework;

namespace CleanArchitecture.Presentation.Sales
{
    [TestFixture]
    public class SalesControllerTests
    {
        private SalesController _controller;
        private AutoMoqer _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _controller = _mocker.Create<SalesController>();
        }

        [Test]
        public void TestGetIndexShouldReturnListOfSales()
        {
            var model = new SalesListItemModel();

            _mocker.GetMock<IGetSalesListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<SalesListItemModel> { model });

            var viewResult = _controller.Index();

            var results = (List<SalesListItemModel>) viewResult.Model;

            Assert.That(results.Single(), Is.EqualTo(model));
        }

        [Test]
        public void TestGetDetailShouldReturnSaleDetail()
        {
            var saleId = 1;

            var model = new SaleDetailModel();

            _mocker.GetMock<IGetSaleDetailQuery>()
                .Setup(p => p.Execute(saleId))
                .Returns(model);

            var viewResult = _controller.Detail(saleId);

            var result = (SaleDetailModel) viewResult.Model;

            Assert.That(result, Is.EqualTo(model));
        }

        [Test]
        public void TestGetCreateShouldReturnCreateSaleViewModel()
        {
            var viewModel = new CreateSaleViewModel();

            _mocker.GetMock<ICreateSaleViewModelFactory>()
                .Setup(p => p.Create())
                .Returns(viewModel);

            var viewResult = _controller.Create();

            var result = (CreateSaleViewModel) viewResult.Model;

            Assert.That(result, Is.EqualTo(viewModel));
        }

        [Test]
        public void TestPostCreateShouldReturnExecuteCreateSaleCommand()
        {
            var model = new CreateSaleModel();

            var viewModel = new CreateSaleViewModel()
            {
                Sale = model
            };

            _controller.Create(viewModel);

            _mocker.GetMock<ICreateSaleCommand>()
                .Verify(p => p.Execute(model));
        }
    }
}