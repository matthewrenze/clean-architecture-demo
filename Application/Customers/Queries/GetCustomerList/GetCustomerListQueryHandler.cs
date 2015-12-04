using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Core.Queries;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Customers.Queries.GetCustomerList
{
    public class GetCustomerListQueryHandler 
        : IQueryHandler<GetCustomerListQuery, List<CustomerModel>>
    {
        private readonly IDatabaseContext _database;

        public GetCustomerListQueryHandler(IDatabaseContext database)
        {
            _database = database;
        }

        public List<CustomerModel> Execute(GetCustomerListQuery query)
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
