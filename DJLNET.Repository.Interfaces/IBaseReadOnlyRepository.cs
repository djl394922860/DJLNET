using DJLNET.Core.Paging;
using DJLNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Repository.Interfaces
{
    /// <summary>
    /// 只读仓储基接口
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="TPrimaryKey">实体主键</typeparam>
    public interface IBaseReadOnlyRepository<TEntity, TPrimaryKey>
        where TEntity : GenericEntity<TPrimaryKey>, new()
    {
        TEntity GetByKey(TPrimaryKey key);

        Task<TEntity> GetByKeyAsync(TPrimaryKey key);

        TEntity Find(params object[] keyValues);

        Task<TEntity> FindAsync(params object[] keyValues);

        IQueryable<TEntity> Table();

        IQueryable<TEntity> TableNoTrack();

        IPagedList<TEntity> PagingQuery<TKey>(Expression<Func<TEntity, bool>> condition, int pageNum, int pageSize, Expression<Func<TEntity, TKey>> orderby, bool isDesc) where TKey : struct;
    }
}
