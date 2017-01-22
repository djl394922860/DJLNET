using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.WebCore.WebApi
{
    public class ListResponseBase<T> : IResponse
    {
        public List<T> List { get; set; } = new List<T>();
    }
}
