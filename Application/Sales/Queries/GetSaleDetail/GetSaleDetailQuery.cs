using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces.Persistence;

namespace CleanArchitecture.Application.Sales.Queries.GetSaleDetail
{
    public class GetSaleDetailQuery
        : IGetSaleDetailQuery
    {
        private readonly ISaleRepository _repository;

        public GetSaleDetailQuery(ISaleRepository repository)
        {
            _repository = repository;
        }

        public SaleDetailModel Execute(int saleId)
        {
            var sale = _repository.Get(saleId);
            var saleDetail = new SaleDetailModel
            {
                Id = sale.Id,
                Date = sale.Date,
                CustomerName = sale.Customer.Name,
                EmployeeName = sale.Employee.Name,
                ProductName = sale.Product.Name,
                UnitPrice = sale.UnitPrice,
                Quantity = sale.Quantity,
                TotalPrice = sale.TotalPrice
            };

            return saleDetail;
        }
    }
}
