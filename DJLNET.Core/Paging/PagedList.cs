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
        private IQueryable<T> origin;
        private IQueryable<T> query;

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
                this.origin = source.Where(condition);
                this.query = source.Where(condition);
            }
            else
            {
                this.origin = source;
                this.query = source;
            }
            if (isDesc)
            {
                this.query = query.OrderByDescending(orderby);
            }
            else
            {
                this.query = query.OrderBy(orderby);
            }
            this.query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public IQueryable<T> Rows => this.query;


        public int Total => this.origin.Count();
    }
}
