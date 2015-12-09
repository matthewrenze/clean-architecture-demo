using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CleanArchitecture.Application.Products.Queries.GetProductsList;

namespace CleanArchitecture.Presentation.Products
{
    public class ProductsController : Controller
    {
        private readonly IGetProductsListQuery _query;

        public ProductsController(IGetProductsListQuery query)
        {
            _query = query;
        }

        public ViewResult Index()
        {
            var products = _query.Execute();

            return View(products);
        }
    }
}