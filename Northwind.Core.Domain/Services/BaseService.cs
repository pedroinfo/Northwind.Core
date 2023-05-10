using Northwind.Core.Domain.Entities;
using Northwind.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        private readonly IRepositoryGeneric<TEntity> _repository;
     
        public BaseService(IRepositoryGeneric<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual Task Add(TEntity entity)
        {
            return _repository.InsertAsync(entity);
        }

        public int Count(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Exists(string id)
        {
            return null;
          //  return  _repository.Any(id);
        }

        public virtual Task<bool> Exists(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Exists(int id)
        {
            return null; // _repository.Any(x=)
        }

        public virtual Task<List<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual Task<TEntity> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TEntity> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task RemoveById(string id)
        {
            throw new NotImplementedException();
        }

        public virtual Task RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task RemoveById(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

    }
}
