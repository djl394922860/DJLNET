using DJLNET.EntityFramework;
using DJLNET.Model;
using DJLNET.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

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

        public TEntity GetByKey(TPrimaryKey key)
        {
            return _entities.FirstOrDefault(x => x.ID.Equals(key));
        }

        public IQueryable<TEntity> Table()
        {
            return _entities;
        }

        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await this._context.Set<TEntity>().FindAsync(keyValues).ConfigureAwait(continueOnCapturedContext: false);
        }

        public TEntity Find(params object[] keyValues)
        {
            return this._context.Set<TEntity>().Find(keyValues);
        }

        public async Task<TEntity> GetByKeyAsync(TPrimaryKey key)
        {
            return await Task.Run(() => this._entities.FirstOrDefault(x => x.ID.Equals(key)));
        }

        public IQueryable<TEntity> TableNoTrack()
        {
            return this._context.Set<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> PagingQuery<TOrder>(Expression<Func<TEntity, bool>> condition, int pageNum, int pageSize, Expression<Func<TEntity, TOrder>> orderby, bool isDesc) where TOrder : struct
        {
            var query = this._entities.Where(condition);
            if (isDesc)
            {
                query = query.OrderByDescending(orderby);
            }
            else
            {
                query = query.OrderBy(orderby);
            }
            query = query.Skip((pageNum - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}
