using Microsoft.EntityFrameworkCore;
using Northwind.Core.Domain.Repositories;
using Northwind.Core.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Northwind.Core.Infra.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly NorthwindContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(NorthwindContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(string id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<TEntity> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            //DbSet.Update(entity); // se não utilizar o EF atualizará na query apenas os campos alterados, se necessário, avaliar não usar para maior desempenho
            await SaveChanges();
        }

        public virtual async Task RemoveById(string id)
        {
            DbSet.Remove(await DbSet.FindAsync(id)); 
            await SaveChanges();
        }

        public virtual async Task RemoveById(int id)
        {
            DbSet.Remove(await DbSet.FindAsync(id));
            await SaveChanges();
        }
        public virtual async Task RemoveById(Guid id)
        {
            DbSet.Remove(await DbSet.FindAsync(id));
            await SaveChanges();
        }

        public async Task<bool> Exists(string id)
        {
            var result = await GetById(id);
            return result is null ? false : true;
        }

        public async Task<bool> Exists(Guid id)
        {
            var result = await GetById(id);
            return result is null ? false : true;
        }


        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
