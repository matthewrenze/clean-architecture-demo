using System;
using System.Linq;
using CleanArchitecture.Application.Sales.Queries.GetSaleDetails;
using CleanArchitecture.Domain.Sales;
using CleanArchitecture.Specification.Common;
using CleanArchitecture.Specification.Sales.CreateASale;
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
        
        [Then(@"the following results should be displayed:")]
        public void ThenTheFollowingResultsShouldBeDisplayed(Table table)
        {
            var saleRecord = table.CreateInstance<ViewSaleDetailModel>();

            Assert.That(_result.Date,
                Is.EqualTo(saleRecord.Date));

            Assert.That(_result.CustomerName,
                Is.EqualTo(saleRecord.Customer));

            Assert.That(_result.EmployeeName,
                Is.EqualTo(saleRecord.Employee));

            Assert.That(_result.ProductName,
                Is.EqualTo(saleRecord.Product));

            Assert.That(_result.UnitPrice,
                Is.EqualTo(saleRecord.UnitPrice));

            Assert.That(_result.Quantity,
                Is.EqualTo(saleRecord.Quantity));

            Assert.That(_result.TotalPrice,
                Is.EqualTo(saleRecord.TotalPrice));
        }
    }
}
