using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace DJLNET.Core.Cache
{
    public class MemoryCacheManager : ICacheManager
    {
        public void Clear()
        {
            foreach (var item in MemoryCache.Default)
            {
                this.Remove(item.Key);
            }
        }

        public bool Contains(string key)
        {
            return MemoryCache.Default.Contains(key);
        }

        public T Get<T>(string key)
        {
            var t = (T)MemoryCache.Default.Get(key);
            return t;
        }

        public void Remove(string key)
        {
            MemoryCache.Default.Remove(key);
        }

        public void Set(string key, object value, TimeSpan cacheTime)
        {
            MemoryCache.Default.Set(key, value, new CacheItemPolicy { SlidingExpiration = cacheTime });
        }
    }
}
