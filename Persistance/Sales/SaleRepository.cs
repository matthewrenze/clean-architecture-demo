using System.Linq;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Sales;

namespace CleanArchitecture.Persistance.Sales
{
    public class SaleRepository : IRepository<Sale>
    {
        private readonly IDatabaseService _database;

        public SaleRepository(IDatabaseService database)
        {
            _database = database;
        }

        public IQueryable<Sale> GetAll()
        {
            return _database.Sales;
        }

        public Sale Get(int id)
        {
            return _database.Sales
                .Single(p => p.Id == id);
        }

        public void Add(Sale entity)
        {
            _database.Sales.Add(entity);
        }

        public void Remove(Sale entity)
        {
            _database.Sales.Remove(entity);
        }
    }
}