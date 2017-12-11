using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Persistence.Shared;

namespace CleanArchitecture.Persistence.Products
{
    public class ProductRepository 
        : Repository<Product>,
        IProductRepository
    {
        public ProductRepository(IDatabaseContext database) 
            : base(database) { }
    }
}