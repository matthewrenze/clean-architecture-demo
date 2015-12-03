using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Core.Queries;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Sales.Queries.GetSalesList
{
    public class GetSalesQueryHandler 
        : IQueryHandler<GetSalesQuery, List<SalesListItemDto>>
    {
        private readonly IDatabaseContext _database;

        public GetSalesQueryHandler(IDatabaseContext database)
        {
            _database = database;
        }

        public List<SalesListItemDto> Execute(GetSalesQuery query)
        {
            var sales = _database.Sales
                .Select(p => new SalesListItemDto()
                {
                    Id = p.Id, 
                    DateTime = p.DateTime
                });

            return sales.ToList();
        }
    }
}
