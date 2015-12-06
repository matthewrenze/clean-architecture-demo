using System.Collections.Generic;

namespace CleanArchitecture.Application.Sales.Queries.GetSalesList
{
    public interface IGetSalesListQuery
    {
        List<SalesListItemModel> Execute();
    }
}