using System;
using System.Linq;
using CleanArchitecture.Application.Sales.Queries.GetSaleDetail;
using CleanArchitecture.Specification.Common;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CleanArchitecture.Specification.Sales.ViewSaleDetails
{
    [Binding]
    public class ViewSaleDetailsSteps
    {
        private readonly AppContext _appContext;
        private SaleDetailModel _result;

        public ViewSaleDetailsSteps(AppContext appContext)
        {
            _appContext = appContext;
        }

        [When(@"I request the sale details for sale (.*)")]
        public void WhenIRequestTheSaleDetailsForSale(int saleId)
        {
            var query = _appContext.Container.GetInstance<GetSaleDetailQuery>();

            _result = query.Execute(saleId);
        }
        
        [Then(@"the following sale details should be displayed:")]
        public void ThenTheFollowingResultsShouldBeDisplayed(Table table)
        {
            var model = table.CreateInstance<ViewSaleDetailsModel>();

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
