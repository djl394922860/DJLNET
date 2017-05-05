using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Core.Paging
{
    public interface IPagedList<out T> where T : class, new()
    {
        int Total { get; }

        IReadOnlyList<T> Rows { get; }
    }
}
