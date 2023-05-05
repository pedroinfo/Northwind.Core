using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Northwind.Core.Domain.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(string id);
        Task<TEntity> GetById(int id);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task RemoveById(string id);
        Task RemoveById(int id);
        Task RemoveById(Guid id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<bool> Exists(string id);
        Task<bool> Exists(Guid id);
        Task<int> SaveChanges();
    }
}
