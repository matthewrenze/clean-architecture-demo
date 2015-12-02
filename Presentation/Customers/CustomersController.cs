using System;
using System.Web.Mvc;

namespace CleanArchitecture.Presentation.Customers
{
    public class CustomersController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}