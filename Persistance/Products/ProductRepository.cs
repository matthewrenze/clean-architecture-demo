using System.Linq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Persistance.Shared;

namespace CleanArchitecture.Persistance.Products
{
    public class ProductRepository 
        : Repository<Product>
    {
        public ProductRepository(IDatabaseService database) 
            : base(database) { }
    }
}