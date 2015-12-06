using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Sales.Queries.GetSaleDetails
{
    public class GetSaleDetailQuery
        : IGetSaleDetailQuery
    {
        private readonly IDatabaseContext _database;

        public GetSaleDetailQuery(IDatabaseContext database)
        {
            _database = database;
        }

        public SaleDetailModel Execute(int saleId)
        {
            var sale = _database.Sales
                .Where(p => p.Id == saleId)
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
