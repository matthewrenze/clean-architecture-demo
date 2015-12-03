using System;
using System.Web.Mvc;
using CleanArchitecture.Application.Core.MessageBus;
using CleanArchitecture.Application.Vendors.Queries.GetVendorsList;

namespace CleanArchitecture.Presentation.Vendors
{
    public class VendorsController : Controller
    {
        private readonly IMessageBus _messageBus;

        public VendorsController(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public ActionResult Index()
        {
            var vendors = _messageBus.Execute(new GetVendorsListQuery());

            return View(vendors);
        }
    }
}