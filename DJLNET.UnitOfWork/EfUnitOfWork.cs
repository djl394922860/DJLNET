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

        private DbContextTransaction _dbTransaction;

        public EfUnitOfWork(IDbContext context)
        {
            this._context = context;
        }

        public void BeginTransaction()
        {
            _dbTransaction = _context.Database.BeginTransaction();
        }

        public bool Add<TEntity>(TEntity entity) where TEntity : class, new()
        {
            this._context.Set<TEntity>().Add(entity);
            if (this._dbTransaction != null)
            {
                return this._context.SaveChanges() > 0;
            }
            return true;
        }

        public bool Commit()
        {
            if (this._dbTransaction != null)
            {
                try
                {
                    this._dbTransaction.Commit();
                }
                catch (Exception)
                {
                    this._dbTransaction.Rollback();
                    // 记录数据异常
                    return false;
                }
                return true;
            }
            else
            {
                return this._context.SaveChanges() > 0;
            }
        }

        public bool Delete<TEntity>(TEntity entity) where TEntity : class, new()
        {
            this._context.Set<TEntity>().Remove(entity);
            if (this._dbTransaction != null)
            {
                return this._context.SaveChanges() > 0;
            }
            return true;
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return this._context.Database.ExecuteSqlCommand(TransactionalBehavior.EnsureTransaction, sql, parameters);
        }

        public bool Update<TEntity>(TEntity entity) where TEntity : class, new()
        {
            this._context.Entry<TEntity>(entity).State = EntityState.Modified;
            if (this._dbTransaction != null)
            {
                return this._context.SaveChanges() > 0;
            }
            return true;
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await this._context.Database.ExecuteSqlCommandAsync(TransactionalBehavior.EnsureTransaction, sql, parameters);
        }

        public async Task<bool> CommitAsync()
        {
            if (this._dbTransaction != null)
            {
                try
                {
                    this._dbTransaction.Commit();
                }
                catch (Exception)
                {
                    this._dbTransaction.Rollback();
                    return await Task.FromResult<bool>(false);
                }
                return await Task.FromResult<bool>(true);
            }
            return await this._context.SaveChangesAsync() > 0;
        }
    }
}
