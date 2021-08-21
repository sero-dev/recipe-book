using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public T Add(T item)
        {
            T savedItem = Context.Set<T>().Add(item).Entity;
            Context.SaveChanges();

            return savedItem;
        }

        public void AddRange(IEnumerable<T> items)
        {
            Context.Set<T>().AddRange(items);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public void Remove(T item)
        {
            Context.Set<T>().Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            Context.Set<T>().RemoveRange(items);
        }

        public void Update(T item)
        {
            Context.Set<T>().Update(item);
        }

        public void UpdateRange(IEnumerable<T> items)
        {
            Context.Set<T>().UpdateRange(items);
        }
    }
}
