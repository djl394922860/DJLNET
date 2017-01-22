using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.WebCore.WebApi
{
    /// <summary>
    /// webapi 使用者请求基类
    /// </summary>
    public abstract class UserRequestBase : IRequest
    {
        /// <summary>
        /// 客户端密钥,服务端申请
        /// </summary>
        public string ClientKey { get; set; }

        /// <summary>
        /// 参数签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public long Timestamp { get; set; }
    }
}
