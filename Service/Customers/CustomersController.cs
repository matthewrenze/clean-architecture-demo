using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CleanArchitecture.Application.Customers.Queries.GetCustomerList;

namespace CleanArchitecture.Service.Customers
{
    public class CustomersController : ApiController
    {
        private readonly IGetCustomersListQuery _query;

        public CustomersController(IGetCustomersListQuery query)
        {
            _query = query;
        }

        public IEnumerable<CustomerModel> Get()
        {
            return _query.Execute();
        }
    }
}