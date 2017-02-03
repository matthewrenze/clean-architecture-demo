using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Persistance
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