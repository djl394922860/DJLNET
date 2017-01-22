using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Model.Models
{
    public class WebApiCallLog : GenericEntity<int>
    {
        public WebApiMsgType ApiLogType { get; set; } = WebApiMsgType.None;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public string ClientKey { get; set; }
        public string ClientIpAddress { get; set; }
        public string Message { get; set; }
    }
    public enum WebApiMsgType
    {
        [Description("正常")]
        None,
        [Description(description: "签名失败")]
        SignFail,
        [Description(description: "接口过期")]
        ApiExpires,
        [Description(description: "身份认证失败")]
        AuthencateFail
    }
}
