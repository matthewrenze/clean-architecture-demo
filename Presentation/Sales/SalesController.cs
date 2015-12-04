using System;
using System.Web.Mvc;
using CleanArchitecture.Application.Core.MessageBus;
using CleanArchitecture.Application.Sales.Queries.GetSaleDetails;
using CleanArchitecture.Application.Sales.Queries.GetSalesList;

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
    }
}