using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DJLNET.WebMvc.App_Start.MiniProfilerActivator), "Start", Order = 0)]
namespace DJLNET.WebMvc.App_Start
{
    public static class MiniProfilerActivator
    {
        public static void Start()
        {
            var enable = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["MiniProfilerEnabled"]);
            if (enable)
            {
                DynamicModuleUtility.RegisterModule(typeof(MiniProfilerStartUpModule));
                GlobalFilters.Filters.Add(new StackExchange.Profiling.Mvc.ProfilingActionFilter());
                StackExchange.Profiling.EntityFramework6.MiniProfilerEF6.Initialize();
                MiniProfiler.Settings.PopupShowTimeWithChildren = true;

                var viewEngines = ViewEngines.Engines.ToList();
                ViewEngines.Engines.Clear();

                foreach (var item in viewEngines)
                {
                    var wapper = new StackExchange.Profiling.Mvc.ProfilingViewEngine(item);
                    ViewEngines.Engines.Add(wapper);
                }

            }
        }
    }

    public class MiniProfilerStartUpModule : IHttpModule
    {
        private static bool enable = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["MiniProfilerEnabled"]);
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
            context.EndRequest += Context_EndRequest;
        }

        private void Context_EndRequest(object sender, EventArgs e)
        {
            MiniProfiler.Stop();
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            if (enable)
            {
                MiniProfiler.Start();
            }
        }
    }
}