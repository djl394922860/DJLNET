using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DJLNET.WebMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MvcHandler.DisableMvcResponseHeader = true;
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var viewEngines = ViewEngines.Engines.ToList();
            ViewEngines.Engines.Clear();

            foreach (var item in viewEngines)
            {
                var wapper = new StackExchange.Profiling.Mvc.ProfilingViewEngine(item);
                ViewEngines.Engines.Add(wapper);
            }

        }

        protected void Application_BeginRequest()
        {
            if (Request.IsLocal)
            {
                StackExchange.Profiling.MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }
    }
}
