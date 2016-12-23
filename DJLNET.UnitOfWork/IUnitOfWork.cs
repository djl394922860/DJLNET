using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        int ExecuteSqlCommand(string sql, params object[] parameters);

        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);

        bool Add<TEntity>(TEntity entity)
            where TEntity : class;

        bool Update<TEntity>(TEntity entity)
            where TEntity : class;

        bool Delete<TEntity>(TEntity entity)
            where TEntity : class;

        bool Commit();

        Task<bool> CommitAsync();

        void Rollback();
    }
}
