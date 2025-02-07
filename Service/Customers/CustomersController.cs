using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Customers.Queries.GetCustomerList;

namespace CleanArchitecture.Service.Customers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IGetCustomersListQuery _query;

        public CustomersController(IGetCustomersListQuery query)
        {
            _query = query;
        }

        [HttpGet]
        public IEnumerable<CustomerModel> Get()
        {
            return _query.Execute();
        }
    }
}