using Microsoft.EntityFrameworkCore;
using Northwind.Core.Domain;
using Northwind.Core.Domain.Entities;
using Northwind.Core.Infra.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Northwind.Core.Infra.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            TEntity existing = _unitOfWork.Context.Set<TEntity>().Find(entity);
            if (existing != null) _unitOfWork.Context.Set<TEntity>().Remove(existing);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _unitOfWork.Context.Set<TEntity>().AsEnumerable<TEntity>();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.Context.Set<TEntity>().Where(predicate).AsEnumerable<TEntity>();
        }

        public void Update(TEntity entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<TEntity>().Attach(entity);
        }

    }
}
