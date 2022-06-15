﻿using Core.Entities;
using System.Linq.Expressions;

namespace Core.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveChangesAsync();
        Task<T> FindEntityByConditionAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindEntitiesByConditionAsync(Expression<Func<T, bool>> predicate);
    }
}
