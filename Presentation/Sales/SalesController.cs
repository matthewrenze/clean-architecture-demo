using System;
using System.Linq;
using System.Web.Mvc;
using CleanArchitecture.Application.Core.MessageBus;
using CleanArchitecture.Application.Customers.Queries.GetCustomerList;
using CleanArchitecture.Application.Employees.Queries.GetEmployeesList;
using CleanArchitecture.Application.Products.Queries.GetProductsList;
using CleanArchitecture.Application.Sales.Commands.CreateSale;
using CleanArchitecture.Application.Sales.Queries.GetSaleDetails;
using CleanArchitecture.Application.Sales.Queries.GetSalesList;
using CleanArchitecture.Presentation.Sales.Models;

namespace CleanArchitecture.Presentation.Sales
{
    [RoutePrefix("sales")]
    public class SalesController : Controller
    {
        private readonly IMessageBus _messageBus;

        public SalesController(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        [Route("")]
        public ActionResult Index()
        {
            var sales = _messageBus.Execute(new GetSalesQuery());

            return View(sales);
        }

        [Route("{id:int}")]
        public ActionResult Detail(int id)
        {
            var sale = _messageBus.Execute(new GetSaleDetailQuery(id));

            return View(sale);
        }

        [Route("create")]
        public ActionResult Create()
        {
            var employees = _messageBus.Execute(new GetEmployeesListQuery());

            var customers = _messageBus.Execute(new GetCustomerListQuery());

            var products = _messageBus.Execute(new GetProductsListQuery());

            var viewModel = new CreateSaleViewModel();
            
            viewModel.Employees = employees
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(), 
                    Text = p.Name
                })
                .ToList();

            viewModel.Customers = customers
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(), 
                    Text = p.Name
                })
                .ToList();

            viewModel.Products = products
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(), 
                    Text = p.Name + " ($" + p.UnitPrice + ")"
                })
                .ToList();

            viewModel.Sale = new CreateSaleModel();

            return View(viewModel);
        }

        [Route("create")]
        [HttpPost]
        public ActionResult Create(CreateSaleViewModel viewModel)
        {
            var model = new CreateSaleModel()
            {
                CustomerId = viewModel.Sale.CustomerId,
                EmployeeId = viewModel.Sale.EmployeeId,
                ProductId = viewModel.Sale.ProductId,
                Quantity = viewModel.Sale.Quantity
            };

            _messageBus.Execute(new CreateSaleCommand(model));

            return RedirectToAction("index", "sales");
        }
    }
}