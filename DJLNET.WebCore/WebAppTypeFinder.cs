using DJLNET.Core.TypeEX;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DJLNET.WebCore
{
    public class WebAppTypeFinder : AppDomainTypeFinder
    {
        private bool binFolderAssembliesLoaded = false;

        public virtual string GetBinDiectory()
        {
            if (System.Web.Hosting.HostingEnvironment.IsHosted)
            {
                return System.Web.HttpRuntime.BinDirectory;
            }
            var dectory = AppDomain.CurrentDomain.BaseDirectory;
            return dectory;
        }

        public override IList<Assembly> GetAssemblies()
        {
            if (!binFolderAssembliesLoaded)
            {
                binFolderAssembliesLoaded = true;
                LoadMatchingAssemblies(GetBinDiectory());
            }
            return base.GetAssemblies();
        }
    }
}
