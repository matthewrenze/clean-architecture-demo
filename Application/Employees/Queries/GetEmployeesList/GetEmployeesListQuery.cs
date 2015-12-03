using System;
using System.Collections.Generic;
using CleanArchitecture.Application.Core.Queries;

namespace CleanArchitecture.Application.Employees.Queries.GetEmployeeList
{
    public class GetEmployeesListQuery 
        : IQuery<List<EmployeesListItemDto>>
    {
    }
}
