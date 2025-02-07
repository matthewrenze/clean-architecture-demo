using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

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