using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace DJLNET.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // url参数配置输出类型
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping(queryStringParameterName: "formate", queryStringParameterValue: "json", mediaType: "application/json"));

            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping(queryStringParameterName: "formate", queryStringParameterValue: "xml", mediaType: "application/xml"));
            // 默认输出json为小写开头
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            // 默认时间处理设置
            config.Formatters.JsonFormatter.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            // 保持json字符串标准格式
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            // 启用跨域请求设置
            config.EnableCors();

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = RouteParameter.Optional
                }
            );
        }
    }
}
