using System;
using System.Linq;
using System.Web.Mvc;
using CleanArchitecture.Application;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Presentation.Home
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}