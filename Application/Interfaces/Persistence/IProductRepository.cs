using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.Products;

namespace CleanArchitecture.Application.Interfaces.Persistence
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
