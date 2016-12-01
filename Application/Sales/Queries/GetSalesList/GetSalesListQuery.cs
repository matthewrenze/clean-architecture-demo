using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Sales.Queries.GetSalesList
{
    public class GetSalesListQuery 
        : IGetSalesListQuery
    {
        private readonly IDatabaseService _database;

        public GetSalesListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<SalesListItemModel> Execute()
        {
            var sales = _database.Sales
                .Select(p => new SalesListItemModel()
                {
                    Id = p.Id, 
                    Date = p.Date,
                    CustomerName = p.Customer.Name,
                    EmployeeName = p.Employee.Name,
                    ProductName = p.Product.Name,
                    UnitPrice = p.UnitPrice,
                    Quantity = p.Quantity,
                    TotalPrice = p.TotalPrice
                });

            return sales.ToList();
        }
    }
}
