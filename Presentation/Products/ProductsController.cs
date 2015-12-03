using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CleanArchitecture.Application.Core.MessageBus;
using CleanArchitecture.Application.Products.Queries.GetProductsList;
using CleanArchitecture.Presentation.Products.Models;

namespace CleanArchitecture.Presentation.Products
{
    public class ProductsController : Controller
    {
        private readonly IMessageBus _messageBus;

        public ProductsController(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public ActionResult Index()
        {
            var products = _messageBus.Execute(new GetProductsListQuery());

            return View(products);
        }
    }
}