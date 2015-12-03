using System;
using System.Collections.Generic;
using CleanArchitecture.Application.Core.Queries;

namespace CleanArchitecture.Application.Sales.Queries.GetSalesQuery
{
    public class GetSalesQueryHandler 
        : IQueryHandler<GetSalesQuery, List<SalesListModel>>
    {
        public List<SalesListModel> Execute(GetSalesQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
