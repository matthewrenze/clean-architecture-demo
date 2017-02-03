using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Employees;

namespace CleanArchitecture.Application.Interfaces.Persistence
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
