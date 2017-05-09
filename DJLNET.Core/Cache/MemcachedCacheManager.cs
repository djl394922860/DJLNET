using Enyim.Caching;
using Enyim.Caching.Memcached;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Core.Cache
{
    public class MemcachedCacheManager : ICacheManager
    {
        public MemcachedCacheManager()
        {

        }

        private static readonly MemcachedClient client;

        static MemcachedCacheManager()
        {
            client = new MemcachedClient();
        }

        public void Clear()
        {
            client.FlushAll();
        }

        public bool Contains(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            var result = client.ExecuteGet(key);
            if (result.Exception != null) throw new ArgumentException(result.Message, nameof(key));
            return result.HasValue;
        }

        public T Get<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            var str = client.Get<string>(key);
            T t = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str);
            if (t != null) return t;
            return default(T);
        }

        public void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            var result = client.ExecuteRemove(key);
            if (result.Exception != null) throw new ArgumentException(result.Message, nameof(key));
        }

        public void Set(string key, object value, TimeSpan cacheTime)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            if (value == null) throw new ArgumentNullException(nameof(value));
            var str = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            var operateResult = client.ExecuteStore(StoreMode.Set, key, str, cacheTime);
            if (operateResult.Exception != null) throw new ArgumentException(operateResult.Message, nameof(key));
        }
    }
}
