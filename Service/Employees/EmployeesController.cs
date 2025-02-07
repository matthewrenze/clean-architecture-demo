using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Employees.Queries.GetEmployeesList;

namespace CleanArchitecture.Service.Employees
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IGetEmployeesListQuery _query;

        public EmployeesController(IGetEmployeesListQuery query)
        {
            _query = query;
        }
        
        [HttpGet]
        public IEnumerable<EmployeeModel> Get()
        {
            return _query.Execute();
        }
    }
}