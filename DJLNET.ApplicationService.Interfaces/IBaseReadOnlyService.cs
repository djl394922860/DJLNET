using DJLNET.Core.Paging;
using DJLNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.ApplicationService.Interfaces
{
    public interface IBaseReadOnlyService<TEntity, TPrimaryKey> where TEntity : GenericEntity<TPrimaryKey>, new()
    {
        TEntity Get(TPrimaryKey key);

        Task<TEntity> GetAsync(TPrimaryKey key);

        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        IPagedList<TEntity> PagingQuery<TKey>(Expression<Func<TEntity, bool>> condition, int pageNum, int pageSize, Expression<Func<TEntity, TKey>> orderby, bool isDesc) where TKey : struct;

        IPagedList<TEntity> PagingQuery(Expression<Func<TEntity, bool>> condition, int pageNum, int pageSize, string orderbyName, bool isDesc);

        Task<IPagedList<TEntity>> PagingQueryAsync(Expression<Func<TEntity, bool>> condition, int pageNum, int pageSize, string orderbyName, bool isDesc);

        Task<IPagedList<TEntity>> PagingQueryAsync<TKey>(Expression<Func<TEntity, bool>> condition, int pageNum, int pageSize, Expression<Func<TEntity, TKey>> orderby, bool isDesc) where TKey : struct;
    }
}
