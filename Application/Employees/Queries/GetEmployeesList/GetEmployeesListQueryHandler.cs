using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Core.Queries;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQueryHandler 
        : IQueryHandler<GetEmployeesListQuery, List<EmployeeModel>>
    {
        private readonly IDatabaseContext _database;

        public GetEmployeesListQueryHandler(IDatabaseContext database)
        {
            _database = database;
        }

        public List<EmployeeModel> Execute(GetEmployeesListQuery query)
        {
            var employees = _database.Employees
                .Select(p => new EmployeeModel
                {
                    Id = p.Id,
                    Name = p.Name
                });               

            return employees.ToList();
        }
    }
}
