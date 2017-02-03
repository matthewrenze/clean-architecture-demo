using System.Linq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Persistance.Shared;

namespace CleanArchitecture.Persistance.Customers
{
    public class CustomerRepository 
        : Repository<Customer>
    {
        public CustomerRepository(IDatabaseService database) 
            : base(database) { }
    }
}