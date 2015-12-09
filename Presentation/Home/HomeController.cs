using System;
using System.Linq;
using System.Web.Mvc;

namespace CleanArchitecture.Presentation.Home
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}