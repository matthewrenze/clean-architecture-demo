using System;
using System.Web.Mvc;
using CleanArchitecture.Application.Core.MessageBus;
using CleanArchitecture.Application.Sales.Queries.GetSalesList;

namespace CleanArchitecture.Presentation.Sales
{
    public class SalesController : Controller
    {
        private readonly IMessageBus _messageBus;

        public SalesController(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public ActionResult Index()
        {
            var sales = _messageBus.Execute(new GetSalesQuery());

            return View(sales);
        }
    }
}