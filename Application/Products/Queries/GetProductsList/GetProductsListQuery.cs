using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces.Persistence;

namespace CleanArchitecture.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery 
        : IGetProductsListQuery
    {
        private readonly IProductRepository _repository;

        public GetProductsListQuery(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<ProductModel> Execute()
        {
            var products = _repository.GetAll()
                .Select(p => new ProductModel
                {
                    Id = p.Id, 
                    Name = p.Name,
                    UnitPrice = p.Price
                });

            return products.ToList();
        }
    }
}
