using System;
using System.Web.Mvc;

namespace CleanArchitecture.Presentation.Sales
{
    public class SalesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}