using DJLNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Repository.Interfaces
{
    public interface IRepository<TEntity, TPrimaryKey>
        where TEntity : GenericEntity<TPrimaryKey>, new()
    {
        TEntity GetByKey(TPrimaryKey key);

        Task<TEntity> FindAsync(params object[] keyValues);

        IQueryable<TEntity> GetAll();
    }
}
