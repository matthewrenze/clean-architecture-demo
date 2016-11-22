using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Specification.Common
{
    public class InMemoryDbSet<T> 
        : IDbSet<T> where T : class
    {
        private readonly HashSet<T> _set;
        private readonly IQueryable<T> _queryableSet;

        public Expression Expression
        {
            get { return _queryableSet.Expression; }
        }

        public Type ElementType
        {
            get { return _queryableSet.ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return _queryableSet.Provider; }
        }

        public ObservableCollection<T> Local
        {
            get { return new ObservableCollection<T>(_queryableSet); }
        }

        public InMemoryDbSet() : this(Enumerable.Empty<T>())
        {

        }

        private InMemoryDbSet(IEnumerable<T> entities)
        {
            _set = new HashSet<T>();

            entities.ToList().ForEach(p => _set.Add(p));

            _queryableSet = _set.AsQueryable();
        }

        public T Create()
        {
            throw new NotImplementedException();
        }

        public T Add(T entity)
        {
            _set.Add(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            _set.Add(entity);
            return entity;
        }

        public T Remove(T entity)
        {
            _set.Remove(entity);
            return entity;
        }

        public T Find(params object[] keyValues)
        {
            return _set.FirstOrDefault(p => ((IEntity) p).Id == (int) keyValues[0]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _queryableSet.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            throw new NotImplementedException();
        }
    }
}
