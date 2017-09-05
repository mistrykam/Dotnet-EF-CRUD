using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Entities.Framework
{
    /// <summary>
    /// Respository is a collection like interface to an TEntity with a TKey
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TKey, TEntity> where TEntity : class
    {
        // Add
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        // Read
        TEntity Get(TKey key);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(int pageIndex, int pageSize);

        // Remove     
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
