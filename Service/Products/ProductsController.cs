using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Products.Queries.GetProductsList;

namespace CleanArchitecture.Service.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGetProductsListQuery _query;

        public ProductsController(IGetProductsListQuery query)
        {
            _query = query;
        }

        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return _query.Execute();
        }
    }
}