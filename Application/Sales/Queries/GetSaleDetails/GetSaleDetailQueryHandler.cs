using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Core.Queries;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Sales.Queries.GetSalesList;

namespace CleanArchitecture.Application.Sales.Queries.GetSaleDetails
{
    public class GetSaleDetailQueryHandler
        : IQueryHandler<GetSaleDetailQuery, SaleDetailModel>
    {
        private readonly IDatabaseContext _database;

        public GetSaleDetailQueryHandler(IDatabaseContext database)
        {
            _database = database;
        }

        public SaleDetailModel Execute(GetSaleDetailQuery query)
        {
            var sale = _database.Sales
                .Where(p => p.Id == query.SaleId)
                .Take(1)
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
                .First();

            return sale;
        }
    }
}
