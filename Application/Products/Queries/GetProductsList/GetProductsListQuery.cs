using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery 
        : IGetProductsListQuery
    {
        private readonly IDatabaseContext _database;

        public GetProductsListQuery(IDatabaseContext database)
        {
            _database = database;
        }

        public List<ProductModel> Execute()
        {
            var products = _database.Products
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
