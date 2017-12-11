using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Persistence.Shared;

namespace CleanArchitecture.Persistence.Employees
{
    public class EmployeeRepository 
        : Repository<Employee>,
        IEmployeeRepository
    {
        public EmployeeRepository(IDatabaseContext database) 
            : base(database) { }
    }
}