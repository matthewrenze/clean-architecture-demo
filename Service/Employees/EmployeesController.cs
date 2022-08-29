using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CleanArchitecture.Application.Employees.Queries.GetEmployeesList;

namespace CleanArchitecture.Service.Employees
{
    public class EmployeesController : ApiController
    {
        private readonly IGetEmployeesListQuery _query;

        public EmployeesController(IGetEmployeesListQuery query)
        {
            _query = query;
        }

        public IEnumerable<EmployeeModel> Get()
        {
            return _query.Execute();
        }
    }
}