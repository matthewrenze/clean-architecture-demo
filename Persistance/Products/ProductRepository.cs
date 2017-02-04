using System.Linq;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Persistance.Shared;

namespace CleanArchitecture.Persistance.Products
{
    public class ProductRepository 
        : Repository<Product>,
        IProductRepository
    {
        public ProductRepository(IDatabaseContext database) 
            : base(database) { }
    }
}