using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DJLNET.Core.Extension;

namespace DJLNET.Core.Paging
{
    public class PagedDynamicList<T> : IPagedList<T> where T : class, new()
    {
        private int _total;
        private IReadOnlyList<T> _list;

        public PagedDynamicList(IQueryable<T> data, Expression<Func<T, bool>> condition, string orderByPropertyName, int pageNumber, int pageSize, bool isDesc)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber, "PageNumber cannot be below 1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "PageSize cannot be less than 1.");
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (string.IsNullOrEmpty(orderByPropertyName))
                throw new ArgumentNullException(nameof(orderByPropertyName));
            if (condition != null)
            {
                data = data.Where(condition);
            }
            if (typeof(T).GetProperty(orderByPropertyName.FirstCharToUpper()) == null)
            {
                throw new ArgumentOutOfRangeException(nameof(orderByPropertyName), $"{nameof(orderByPropertyName)} is not {typeof(T).Name}'s property.");
            }
            _total = data.Count();
            this._list = data.OrderBy(orderByPropertyName, isDesc).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public IReadOnlyList<T> Rows => this._list;

        public int Total => this._total;
    }
}
