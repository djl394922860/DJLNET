using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.WebCore.WebApi
{
    public class ResultObject
    {
        /// <summary>
        /// 等于0表示成功        
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// Success=false，返回错误消息       
        /// </summary>
        public string Msg { get; set; }
    }

    public class ResultObject<TResponse> : ResultObject where TResponse : IResponse
    {
        public ResultObject() { }
        public TResponse Data { get; set; }
        public ResultObject(TResponse data)
        {
            Data = data;
        }
    }
}
