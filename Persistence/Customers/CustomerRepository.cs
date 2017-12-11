using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Persistence.Shared;

namespace CleanArchitecture.Persistence.Customers
{
    public class CustomerRepository 
        : Repository<Customer>, 
        ICustomerRepository
    {
        public CustomerRepository(IDatabaseContext database) 
            : base(database) { }
    }
}