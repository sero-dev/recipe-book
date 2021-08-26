﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        Task<T> GetAsync(int id);

        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        void Add(T item);
        Task AddAsync(T item);

        void Update(T item);
        void Remove(T item);

        void AddRange(IEnumerable<T> items);
        void UpdateRange(IEnumerable<T> item);
        void RemoveRange(IEnumerable<T> items);
    }
}
