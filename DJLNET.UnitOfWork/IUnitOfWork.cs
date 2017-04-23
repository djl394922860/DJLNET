using DJLNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Add<TEntity>(TEntity entity)
            where TEntity : class, new();

        void AddRang<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, new();

        void Update<TEntity>(TEntity entity)
            where TEntity : class, new();

        void Delete<TEntity>(TEntity entity)
            where TEntity : class, new();

        void DeleteRang<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, new();

        int SaveChanges();

        Task<int> SaveChangesAync();
    }
}
