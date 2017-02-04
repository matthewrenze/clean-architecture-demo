using System.Linq;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Sales;
using CleanArchitecture.Persistance.Shared;

namespace CleanArchitecture.Persistance.Sales
{
    public class SaleRepository 
        : Repository<Sale>,
        ISaleRepository
    {
        public SaleRepository(IDatabaseContext database) 
            : base(database) { }
    }
}