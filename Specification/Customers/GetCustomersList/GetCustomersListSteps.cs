using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Customers.Queries.GetCustomerList;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using AppContext = CleanArchitecture.Specification.Shared.AppContext;

namespace CleanArchitecture.Specification.Customers.GetCustomersList
{
    [Binding]
    public class GetCustomersListSteps
    {
        private readonly AppContext _context;
        private List<CustomerModel> _results;

        public GetCustomersListSteps(AppContext context)
        {
            _context = context;
            _results = new List<CustomerModel>();
        }

        [When(@"I request a list of customers")]
        public void WhenIRequestAListOfCustomers()
        {
            var query = _context.Container
                .GetService<IGetCustomersListQuery>();

            _results = query.Execute();
        }
        
        [Then(@"the following customers should be returned:")]
        public void ThenTheFollowingCustomersShouldBeReturned(Table table)
        {
            var models = table.CreateSet<CustomerModel>().ToList();

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
