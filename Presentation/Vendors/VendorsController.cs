using System;
using System.Web.Mvc;

namespace CleanArchitecture.Presentation.Vendors
{
    public class VendorsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}