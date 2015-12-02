using System;
using System.Web.Mvc;

namespace CleanArchitecture.Presentation.Employees
{
    public class EmployeesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}