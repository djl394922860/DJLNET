using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Core
{
    public static class ServiceContainer
    {
        private readonly static IUnityContainer Container;

        static ServiceContainer()
        {
            Container = new UnityContainer();
        }

        public static IUnityContainer CurrentContainer
        {
            get
            {
                return Container;
            }
        }

        public static T Resole<T>() where T : class
        {
            return CurrentContainer.Resolve<T>();
        }

        public static T Resole<T>(string registerName) where T : class
        {
            return CurrentContainer.Resolve<T>(registerName);
        }

        public static IEnumerable<T> ResoleAll<T>() where T : class
        {
            return CurrentContainer.ResolveAll<T>();
        }

        public static bool IsRegisted<T>() where T : class
        {
            return CurrentContainer.IsRegistered<T>();
        }

    }
}
