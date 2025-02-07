using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Products.Queries.GetProductsList;
using CleanArchitecture.Specification.Common;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CleanArchitecture.Specification.Products
{
    [Binding]
    public class GetProductsListSteps
    {
        private readonly AppContext _context;
        private List<ProductModel> _results;

        public GetProductsListSteps(AppContext context)
        {
            _context = context;
        }

        [When(@"I request a list of products")]
        public void WhenIRequestAListOfProducts()
        {
            var query = _context.Container
                .GetInstance<GetProductsListQuery>();

            _results = query.Execute();
        }
        
        [Then(@"the following products should be returned:")]
        public void ThenTheFollowingProductsShouldBeReturned(Table table)
        {
            var models = table.CreateSet<ProductModel>().ToList();

            for (var i = 0; i < models.Count(); i++)
            {
                var model = models[i];

                var result = _results[i];

                Assert.That(result.Id,
                    Is.EqualTo(model.Id));

                Assert.That(result.Name,
                    Is.EqualTo(model.Name));

                Assert.That(result.UnitPrice,
                    Is.EqualTo(model.UnitPrice));
            }
        }
    }
}
