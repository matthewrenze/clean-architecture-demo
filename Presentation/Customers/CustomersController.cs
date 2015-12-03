using System;
using System.Web.Mvc;
using CleanArchitecture.Application.Core.MessageBus;
using CleanArchitecture.Application.Customers.Queries.GetCustomerList;

namespace CleanArchitecture.Presentation.Customers
{
    public class CustomersController : Controller
    {
        private readonly IMessageBus _messageBus;

        public CustomersController(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public ActionResult Index()
        {
            var customers = _messageBus.Execute(new GetCustomerListQuery());

            return View(customers);
        }
    }
}