using CleanArchitecture.Application.Interfaces.Persistence;

namespace CleanArchitecture.Persistance.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext _database;

        public UnitOfWork(IDatabaseContext database)
        {
            _database = database;
        }

        public void Save()
        {
            _database.Save();
        }
    }
}