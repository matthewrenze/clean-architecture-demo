using System.Linq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Persistance.Shared;

namespace CleanArchitecture.Persistance.Employees
{
    public class EmployeeRepository 
        : Repository<Employee>,
        IEmployeeRepository
    {
        public EmployeeRepository(IDatabaseService database) 
            : base(database) { }
    }
}