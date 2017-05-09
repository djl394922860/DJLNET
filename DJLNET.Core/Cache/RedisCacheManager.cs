using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Core.Cache
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly string redisConnectionString;

        private volatile ConnectionMultiplexer redisConnection;

        private static readonly object redisConnectionLock = new object();

        private ConnectionMultiplexer GetRedisConnection()
        {
            if (this.redisConnection != null && this.redisConnection.IsConnected)
            {
                return this.redisConnection;
            }
            lock (redisConnectionLock)
            {
                if (this.redisConnection != null && this.redisConnection.IsConnected) return this.redisConnection;
                if (this.redisConnection != null)
                {
                    this.redisConnection.Dispose();
                }
                this.redisConnection = ConnectionMultiplexer.Connect(this.redisConnectionString);
            }
            return this.redisConnection;
        }

        public RedisCacheManager(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));
            this.redisConnectionString = connectionString;
            this.redisConnection = GetRedisConnection();
        }

        private byte[] Serialize(object value)
        {
            if (value == null) return new byte[] { };
            var str = Newtonsoft.Json.JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings()
            {
                DateFormatString = "yyyy-MM-dd HH:mm:ss"
            });
            var bytes = Encoding.UTF8.GetBytes(str);
            return bytes;
        }

        private T Deserialize<T>(byte[] bytes)
        {
            if (bytes == null || bytes.Length <= 0) return default(T);
            var str = Encoding.UTF8.GetString(bytes);
            var t = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str);
            return t;
        }

        public void Clear()
        {
            foreach (var endPoint in this.redisConnection.GetEndPoints())
            {
                var server = this.redisConnection.GetServer(endPoint);
                foreach (var key in server.Keys())
                {
                    this.redisConnection.GetDatabase().KeyDelete(key);
                }
            }
        }

        public bool Contains(string key)
        {
            return this.redisConnection.GetDatabase().KeyExists(key);
        }

        public T Get<T>(string key)
        {
            var redisValue = this.redisConnection.GetDatabase().StringGet(key);
            if (redisValue.HasValue)
            {
                return Deserialize<T>(redisValue);
            }
            return default(T);
        }

        public void Remove(string key)
        {
            this.redisConnection.GetDatabase().KeyDelete(key);
        }

        public void Set(string key, object value, TimeSpan cacheTime)
        {
            if (value != null)
            {
                this.redisConnection.GetDatabase().StringSet(key, Serialize(value), cacheTime);
            }
        }
    }
}
