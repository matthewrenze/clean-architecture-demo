using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Sales.Queries.GetSalesList;
using CleanArchitecture.Specification.Common;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using AppContext = CleanArchitecture.Specification.Common.AppContext;

namespace CleanArchitecture.Specification.Sales.GetSalesList
{
    [Binding]
    public class GetSalesListSteps
    {
        private readonly AppContext _context;
        private List<SalesListItemModel> _results;

        public GetSalesListSteps(AppContext context)
        {
            _context = context;
        }

        [When(@"I request a list of sales")]
        public void WhenIRequestAListOfSales()
        {
            var query = _context.Container
                .GetInstance<GetSalesListQuery>();

            _results = query.Execute();
        }
        
        [Then(@"the following sales list should be returned:")]
        public void ThenTheFollowingSalesShouldBeReturned(Table table)
        {
            var models = table.CreateSet<GetSalesListModel>().ToList();

            for (var i = 0; i < models.Count(); i++)
            {
                var model = models[i];

                var result = _results[i];

                Assert.That(result.Id,
                    Is.EqualTo(model.Id));

                Assert.That(result.Date,
                    Is.EqualTo(model.Date));

                Assert.That(result.CustomerName,
                    Is.EqualTo(model.Customer));

                Assert.That(result.EmployeeName,
                    Is.EqualTo(model.Employee));

                Assert.That(result.ProductName,
                    Is.EqualTo(model.Product));

                Assert.That(result.UnitPrice,
                    Is.EqualTo(model.UnitPrice));

                Assert.That(result.Quantity,
                    Is.EqualTo(model.Quantity));

                Assert.That(result.TotalPrice,
                    Is.EqualTo(model.TotalPrice));

            }            
        }
    }
}
