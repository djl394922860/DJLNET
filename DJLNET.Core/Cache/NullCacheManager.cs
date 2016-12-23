using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Core.Cache
{
    public class NullCacheManager : ICacheManager
    {
        public void Clear()
        {

        }

        public bool Contains(string key)
        {
            return false;
        }

        public T Get<T>(string key)
        {
            return default(T);
        }

        public void Remove(string key)
        {
        }

        public void Set(string key, object value, TimeSpan cacheTime)
        {

        }
    }
}
