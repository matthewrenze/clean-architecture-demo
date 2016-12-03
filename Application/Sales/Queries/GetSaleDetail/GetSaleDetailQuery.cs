using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Sales.Queries.GetSaleDetail
{
    public class GetSaleDetailQuery
        : IGetSaleDetailQuery
    {
        private readonly IDatabaseService _database;

        public GetSaleDetailQuery(IDatabaseService database)
        {
            _database = database;
        }

        public SaleDetailModel Execute(int saleId)
        {
            var sale = _database.Sales
                .Where(p => p.Id == saleId)
                .Select(p => new SaleDetailModel()
                {
                    Id = p.Id, 
                    Date = p.Date,
                    CustomerName = p.Customer.Name,
                    EmployeeName = p.Employee.Name,
                    ProductName = p.Product.Name,
                    UnitPrice = p.UnitPrice,
                    Quantity = p.Quantity,
                    TotalPrice = p.TotalPrice
                })
                .Single();

            return sale;
        }
    }
}
