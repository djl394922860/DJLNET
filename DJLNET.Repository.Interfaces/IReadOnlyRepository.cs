using DJLNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Repository.Interfaces
{
    /// <summary>
    /// 只读仓储基接口
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="TPrimaryKey">实体主键</typeparam>
    public interface IReadOnlyRepository<TEntity, TPrimaryKey>
        where TEntity : GenericEntity<TPrimaryKey>, new()
    {
        TEntity GetByKey(TPrimaryKey key);

        TEntity Find(params object[] keyValues);

        Task<TEntity> FindAsync(params object[] keyValues);

        IQueryable<TEntity> Table();
    }
}
