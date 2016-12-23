using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Core.Cache
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        void Set(string key, object value, TimeSpan cacheTime);

        bool Contains(string key);

        void Remove(string key);

        void Clear();
    }
}
