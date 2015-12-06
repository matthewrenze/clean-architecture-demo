using System;
using System.Linq;
using System.Web.Mvc;
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
        private readonly IGetSalesListQuery _salesListQuery;
        private readonly IGetSaleDetailQuery _salesDetailQuery;
        private readonly IGetCustomersListQuery _customersQuery;
        private readonly IGetEmployeesListQuery _employeesQuery;
        private readonly IGetProductsListQuery _productsQuery;
        private readonly ICreateSaleCommand _createCommand;

        public SalesController(
            IGetSalesListQuery salesListQuery,
            IGetSaleDetailQuery salesDetailQuery,
            IGetCustomersListQuery customersQuery,
            IGetEmployeesListQuery employeesQuery,
            IGetProductsListQuery productsQuery,
            ICreateSaleCommand createCommand)
        {
            _salesListQuery = salesListQuery;
            _salesDetailQuery = salesDetailQuery;
            _customersQuery = customersQuery;
            _employeesQuery = employeesQuery;
            _productsQuery = productsQuery;
            _createCommand = createCommand;
        }

        [Route("")]
        public ActionResult Index()
        {
            var sales = _salesListQuery.Execute();

            return View(sales);
        }

        [Route("{id:int}")]
        public ActionResult Detail(int id)
        {
            var sale = _salesDetailQuery.Execute(id);

            return View(sale);
        }

        [Route("create")]
        public ActionResult Create()
        {
            var employees = _employeesQuery.Execute();

            var customers = _customersQuery.Execute();

            var products = _productsQuery.Execute();

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

            _createCommand.Execute(model);

            return RedirectToAction("index", "sales");
        }
    }
}