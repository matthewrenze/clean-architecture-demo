using System.Collections.Generic;

namespace CleanArchitecture.Application.Products.Queries.GetProductsList
{
    public interface IGetProductsListQuery
    {
        List<ProductModel> Execute();
    }
}