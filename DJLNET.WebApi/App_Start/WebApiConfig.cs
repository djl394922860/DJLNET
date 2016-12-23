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
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping(queryStringParameterName: "formate", queryStringParameterValue: "json", mediaType: "application/json"));

            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping(queryStringParameterName: "formate", queryStringParameterValue: "xml", mediaType: "application/xml"));
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";

            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "GetAllTests",
                    id = RouteParameter.Optional
                }
            );
        }
    }
}
