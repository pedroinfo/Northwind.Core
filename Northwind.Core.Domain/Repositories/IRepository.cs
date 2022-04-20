using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Northwind.Core.Domain.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(string id);
        Task<TEntity> ObterPorId_Int(int id);
        Task<TEntity> ObterPorId_Guid(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(string id);
        Task Remover_Int(int id);
        Task Remover_Guid(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<bool> Existe(string id);
        Task<bool> Existe_Guid(Guid id);
        Task<int> SaveChanges();
    }
}
