using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.Employees;

namespace CleanArchitecture.Application.Interfaces.Persistence
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
