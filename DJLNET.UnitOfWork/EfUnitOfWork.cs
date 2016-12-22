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

        public bool Add<TEntity>(TEntity entity) where TEntity : class
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
                this._dbTransaction.Commit();
                return true;
            }
            else
            {
                return this._context.SaveChanges() > 0;
            }
        }

        public bool Delete<TEntity>(TEntity entity) where TEntity : class
        {
            this._context.Entry<TEntity>(entity).State = EntityState.Deleted;
            if (this._dbTransaction != null)
            {
                return this._context.SaveChanges() > 0;
            }
            return true;
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return this._context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sql, parameters);
        }

        public void Rollback()
        {
            if (this._dbTransaction != null)
            {
                this._dbTransaction.Rollback();
            }
        }

        public bool Update<TEntity>(TEntity entity) where TEntity : class
        {
            this._context.Entry<TEntity>(entity).State = EntityState.Modified;
            if (this._dbTransaction != null)
            {
                return this._context.SaveChanges() > 0;
            }
            return true;
        }
    }
}
