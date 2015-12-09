using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Customers.Queries.GetCustomerList
{
    public class GetCustomersListQuery 
        : IGetCustomersListQuery
    {
        private readonly IDatabaseContext _database;

        public GetCustomersListQuery(IDatabaseContext database)
        {
            _database = database;
        }

        public List<CustomerModel> Execute()
        {
            var customers = _database.Customers
                .Select(p => new CustomerModel()
                {
                    Id = p.Id, 
                    Name = p.Name
                });

            return customers.ToList();
        }
    }
}
