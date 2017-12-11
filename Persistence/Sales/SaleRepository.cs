using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Sales;
using CleanArchitecture.Persistence.Shared;

namespace CleanArchitecture.Persistence.Sales
{
    public class SaleRepository 
        : Repository<Sale>,
        ISaleRepository
    {
        public SaleRepository(IDatabaseContext database) 
            : base(database) { }
    }
}