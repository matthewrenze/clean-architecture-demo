using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Employees.Queries.GetEmployeesList;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using AppContext = CleanArchitecture.Specification.Shared.AppContext;

namespace CleanArchitecture.Specification.Employees.GetEmployeesList
{
    [Binding]
    public class GetEmployeesListSteps
    {
        private readonly AppContext _context;
        private List<EmployeeModel> _results;

        public GetEmployeesListSteps(AppContext context)
        {
            _context = context;
            _results = new List<EmployeeModel>();
        }

        [When(@"I request a list of employees")]
        public void WhenIRequestAListOfEmployees()
        {
            var query = _context.Container
                .GetService<IGetEmployeesListQuery>();

            _results = query.Execute();
        }
        
        [Then(@"the following employees should be returned:")]
        public void ThenTheFollowingEmployeesShouldBeReturned(Table table)
        {
            var models = table.CreateSet<EmployeeModel>().ToList();

            for (var i = 0; i < models.Count; i++)
            {
                var model = models[i];

                var result = _results[i];

                Assert.That(result.Id,
                    Is.EqualTo(model.Id));

                Assert.That(result.Name,
                    Is.EqualTo(model.Name));
            }
        }
    }
}
