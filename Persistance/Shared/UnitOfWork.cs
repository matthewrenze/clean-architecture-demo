using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Interfaces.Persistence;

namespace CleanArchitecture.Persistance.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseService _database;

        public UnitOfWork(IDatabaseService database)
        {
            _database = database;
        }

        public void Save()
        {
            _database.Save();
        }
    }
}