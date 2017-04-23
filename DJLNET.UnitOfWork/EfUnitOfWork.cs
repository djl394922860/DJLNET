using DJLNET.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;

        public EfUnitOfWork(IDbContext context)
        {
            this._context = context;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class, new()
        {
            this._context.Set<TEntity>().Add(entity);
        }

        public int SaveChanges()
        {
            return this._context.SaveChanges();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class, new()
        {
            this._context.Set<TEntity>().Remove(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class, new()
        {
            this._context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public async Task<int> SaveChangesAync()
        {
            return await this._context.SaveChangesAsync();
        }

        public void AddRang<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, new()
        {
            this._context.Set<TEntity>().AddRange(entities);
        }

        public void DeleteRang<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, new()
        {
            this._context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
