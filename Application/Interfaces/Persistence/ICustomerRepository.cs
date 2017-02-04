using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.Customers;

namespace CleanArchitecture.Application.Interfaces.Persistence
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}
