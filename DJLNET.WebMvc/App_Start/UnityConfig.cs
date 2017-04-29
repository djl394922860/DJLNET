using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using DJLNET.Core;
using DJLNET.EntityFramework;
using DJLNET.Repository.Interfaces;
using DJLNET.Repository;
using Microsoft.Practices.Unity.Mvc;
using DJLNET.UnitOfWork;
using DJLNET.ApplicationService.Interfaces;
using System.Reflection;
using System.Linq;
using AutoMapper;
using DJLNET.ApplicationService;

namespace DJLNET.WebMvc.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = ServiceContainer.Current;
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<IDbContext, DJLNETDBContext>(new PerRequestLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IUnitOfWork, EfUnitOfWork>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IRoleService, RoleService>();

            // automapper ע��
            var profiles = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && t.IsSubclassOf(typeof(Profile)));

            var profileInstances = profiles.Select(x => Activator.CreateInstance(x)).Cast<Profile>();

            var mapperConfig = new MapperConfiguration(config => profileInstances.ToList().ForEach(p => config.AddProfile(p)));

            var mapper = mapperConfig.CreateMapper();

            container.RegisterInstance(mapper);
        }
    }
}
