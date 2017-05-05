using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Core.Paging
{
    public class PagedList<T, TKey> : IPagedList<T> where T : class, new() where TKey : struct
    {
        private int _total;
        private IReadOnlyList<T> _list;

        public PagedList(IQueryable<T> source, Expression<Func<T, bool>> condition, Expression<Func<T, TKey>> orderby, int pageNumber, int pageSize, bool isDesc)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber, "PageNumber cannot be below 1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "PageSize cannot be less than 1.");
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (orderby == null)
                throw new ArgumentNullException(nameof(orderby));
            if (condition != null)
            {
                source = source.Where(condition);
            }
            _total = source.Count();
            if (isDesc)
            {
                source = source.OrderByDescending(orderby);
            }
            else
            {
                source = source.OrderBy(orderby);
            }
            this._list = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public IReadOnlyList<T> Rows => this._list ?? new List<T>(0);


        public int Total => this._total;
    }
}
