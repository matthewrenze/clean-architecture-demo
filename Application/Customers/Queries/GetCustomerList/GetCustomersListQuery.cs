using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces.Persistence;

namespace CleanArchitecture.Application.Customers.Queries.GetCustomerList
{
    public class GetCustomersListQuery 
        : IGetCustomersListQuery
    {
        private readonly ICustomerRepository _repository;

        public GetCustomersListQuery(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public List<CustomerModel> Execute()
        {
            var customers = _repository.GetAll()
                .Select(p => new CustomerModel()
                {
                    Id = p.Id, 
                    Name = p.Name
                });

            return customers.ToList();
        }
    }
}
