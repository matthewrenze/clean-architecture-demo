using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Sales.Queries.GetSaleDetail;
using CleanArchitecture.Specification.Shared;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using AppContext = CleanArchitecture.Specification.Shared.AppContext;

namespace CleanArchitecture.Specification.Sales.GetSaleDetails
{
    [Binding]
    public class GetSaleDetailsSteps
    {
        private readonly AppContext _context;
        private SaleDetailModel _result;

        public GetSaleDetailsSteps(AppContext context)
        {
            _context = context;
            _result = new SaleDetailModel();
        }

        [When(@"I request the sale details for sale (.*)")]
        public void WhenIRequestTheSaleDetailsForSale(int saleId)
        {
            var query = _context.Container
                .GetService<IGetSaleDetailQuery>();

            _result = query.Execute(saleId);
        }
        
        [Then(@"the following sale details should be returned:")]
        public void ThenTheFollowingResultsShouldBeReturned(Table table)
        {
            var model = table.CreateInstance<GetSaleDetailsModel>();

            Assert.That(_result.Id,
                Is.EqualTo(model.Id));

            Assert.That(_result.Date,
                Is.EqualTo(model.Date));

            Assert.That(_result.CustomerName,
                Is.EqualTo(model.Customer));

            Assert.That(_result.EmployeeName,
                Is.EqualTo(model.Employee));

            Assert.That(_result.ProductName,
                Is.EqualTo(model.Product));

            Assert.That(_result.UnitPrice,
                Is.EqualTo(model.UnitPrice));

            Assert.That(_result.Quantity,
                Is.EqualTo(model.Quantity));

            Assert.That(_result.TotalPrice,
                Is.EqualTo(model.TotalPrice));
        }
    }
}
