using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        T Add(T item);

        void AddRange(IEnumerable<T> items);

        void Update(T item);

        void UpdateRange(IEnumerable<T> item);

        void Remove(T item);

        void RemoveRange(IEnumerable<T> items);
    }
}
