using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Sales.Commands.CreateSale;
using CleanArchitecture.Application.Sales.Queries.GetSaleDetail;
using CleanArchitecture.Application.Sales.Queries.GetSalesList;
using CleanArchitecture.Presentation.Sales.Models;
using CleanArchitecture.Presentation.Sales.Services;

namespace CleanArchitecture.Presentation.Sales
{
    [Route("sales")]
    public class SalesController : Controller
    {
        private readonly IGetSalesListQuery _salesListQuery;
        private readonly IGetSaleDetailQuery _saleDetailQuery;
        private readonly ICreateSaleViewModelFactory _factory;
        private readonly ICreateSaleCommand _createCommand;

        public SalesController(
            IGetSalesListQuery salesListQuery,
            IGetSaleDetailQuery saleDetailQuery,
            ICreateSaleViewModelFactory factory,
            ICreateSaleCommand createCommand)
        {
            _salesListQuery = salesListQuery;
            _saleDetailQuery = saleDetailQuery;
            _factory = factory;
            _createCommand = createCommand;
        }

        [Route("")]
        public ViewResult Index()
        {
            var sales = _salesListQuery.Execute();

            return View(sales);
        }

        [Route("{id:int}")]
        public ViewResult Detail(int id)
        {
            var sale = _saleDetailQuery.Execute(id);

            return View(sale);
        }

        [Route("create")]
        public ViewResult Create()
        {
            var viewModel = _factory.Create();

            return View(viewModel);
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(CreateSaleViewModel viewModel)
        {
            var model = viewModel.Sale;            

            _createCommand.Execute(model);

            return RedirectToAction("index", "sales");
        }
    }
}