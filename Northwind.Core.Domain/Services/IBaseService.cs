using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Northwind.Core.Domain.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(string id);
        Task<TEntity> GetById(int id);
        Task<TEntity> GetById(Guid id);
        int Count(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task RemoveById(string id);
        Task RemoveById(int id);
        Task RemoveById(Guid id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<bool> Exists(string id);
        Task<bool> Exists(Guid id);
    }
}
