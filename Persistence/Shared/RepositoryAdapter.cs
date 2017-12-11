using System.Data.Entity;
using System.Linq;
using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Persistence.Shared
{
    public class RepositoryAdapter<T> 
        : IRepository<T> 
        where T : class
    {
        private readonly IDbSet<T> _dbSet;

        public RepositoryAdapter(IDbSet<T> dbSet)
        {
            _dbSet = dbSet;
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;            
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
