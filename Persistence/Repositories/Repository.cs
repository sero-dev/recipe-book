using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public void Add(T item)
        {
            Context.Set<T>().Add(item);
            Context.SaveChanges();
        }
        
        public async Task AddAsync(T item)
        {
            await Context.Set<T>().AddAsync(item);
            Context.SaveChanges();
        }

        public void Remove(int id)
        {
            var item = Get(id);
            Context.Set<T>().Remove(item);
            Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id) {
            var item = await GetAsync(id);
            Context.Set<T>().Remove(item);
            await Context.SaveChangesAsync();
        }

        public void Update(T item)
        {
            Context.Set<T>().Update(item);
            Context.SaveChanges();
        }

        public async Task UpdateAsync(T item)
        {
            Context.Set<T>().Update(item);
            await Context.SaveChangesAsync();
        }

        public void AddRange(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }
    }
}
