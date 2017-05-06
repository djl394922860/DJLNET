using DJLNET.EntityFramework;
using DJLNET.Model;
using DJLNET.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DJLNET.Core.Paging;
using DJLNET.Core.Extension;

namespace DJLNET.Repository
{
    public class BaseReadOnlyRepository<TEntity, TPrimaryKey> : IBaseReadOnlyRepository<TEntity, TPrimaryKey>
        where TEntity : GenericEntity<TPrimaryKey>, new()
    {
        public readonly IDbContext _context;

        public readonly IQueryable<TEntity> _entities;

        public BaseReadOnlyRepository(IDbContext context)
        {
            this._context = context;
            this._entities = context.Set<TEntity>();
        }

        public virtual TEntity GetByKey(TPrimaryKey key)
        {
            Expression<Func<TEntity, bool>> asd = w => w.ID.Equals(key);

            // x=>x.ID==key

            var param = Expression.Parameter(typeof(TEntity), "x");

            var prop = Expression.Property(param, nameof(GenericEntity<TPrimaryKey>.ID));

            var methods = typeof(TPrimaryKey).GetMethods();
            foreach (var item in methods)
            {
                System.Diagnostics.Debug.WriteLine(item.Name);
            }

            var method = typeof(TPrimaryKey).GetMethods().Last(x => x.Name == "Equals");

            var constant = Expression.Constant(key, typeof(TPrimaryKey));

            var body = Expression.Call(prop, method, constant);

            var fk = Expression.Lambda<Func<TEntity, bool>>(body, param);

            return _entities.FirstOrDefault(fk);

            //return _entities.FirstOrDefault(x => x.ID.Equals((TPrimaryKey)key));
        }

        public virtual IQueryable<TEntity> Table()
        {
            return _entities;
        }

        public virtual async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await this._context.Set<TEntity>().FindAsync(keyValues).ConfigureAwait(continueOnCapturedContext: false);
        }

        public virtual TEntity Find(params object[] keyValues)
        {
            return this._context.Set<TEntity>().Find(keyValues);
        }

        public virtual async Task<TEntity> GetByKeyAsync(TPrimaryKey key)
        {
            return await Task.Run(() => this._entities.FirstOrDefault(x => x.ID.Equals(key)));
        }

        public virtual IQueryable<TEntity> TableNoTrack()
        {
            return this._context.Set<TEntity>().AsNoTracking();
        }
    }
}
