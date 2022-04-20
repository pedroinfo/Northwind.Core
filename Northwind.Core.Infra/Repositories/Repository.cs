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

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(string id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<TEntity> ObterPorId_Int(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<TEntity> ObterPorId_Guid(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            //return await DbSet.ToListAsync();
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            //DbSet.Update(entity); // se não utilizar o EF atualizará na query apenas os campos alterados, se necessário, avaliar não usar para maior desempenho
            await SaveChanges();
        }

        public virtual async Task Remover(string id)
        {
            DbSet.Remove(await DbSet.FindAsync(id)); //Consulta objeto e entrega para exclusão
            //DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public virtual async Task Remover_Int(int id)
        {
            DbSet.Remove(await DbSet.FindAsync(id)); //Consulta objeto e entrega para exclusão
            //DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }
        public virtual async Task Remover_Guid(Guid id)
        {
            DbSet.Remove(await DbSet.FindAsync(id));
            await SaveChanges();
        }

        public async Task<bool> Existe(string id)
        {
            var resultado = await ObterPorId(id);
            return resultado is null ? false : true;
        }

        public async Task<bool> Existe_Guid(Guid id)
        {
            var resultado = await ObterPorId_Guid(id);
            return resultado is null ? false : true;
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
