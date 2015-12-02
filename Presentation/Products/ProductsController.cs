using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CleanArchitecture.Presentation.Products.Models;

namespace CleanArchitecture.Presentation.Products
{
    public class ProductsController : Controller
    {
        private readonly List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Ice Cream", Price = 1.23m },
        new Product { Id = 2, Name = "Cake", Price = 2.34m }
    };

        public ActionResult Index()
        {
            return View(_products);
        }

        public ActionResult Details(int id)
        {
            var product = _products
                .First(p => p.Id == id);

            return View(product);
        }
    }
}