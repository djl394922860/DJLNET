using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.WebCore.WebApi
{
    public class PageResponseBase<T> : ListResponseBase<T>
    {
        /// <summary>
        /// 页码数        
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 总条数        
        /// </summary>
        public long TotalCount { get; set; }

        /// <summary>
        /// 每页条数        
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总页数       
        /// </summary>
        public long PageCount { get; set; }
    }
}
