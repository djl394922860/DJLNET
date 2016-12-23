using DJLNET.EntityFramework;
using DJLNET.Model;
using DJLNET.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        public readonly IDbContext _context;

        public readonly IQueryable<TEntity> _entities;

        public BaseRepository(IDbContext context)
        {
            this._context = context;
            this._entities = context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return _entities.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entities;
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await this._context.Set<TEntity>().FindAsync(id).ConfigureAwait(false);
        }
    }
}
