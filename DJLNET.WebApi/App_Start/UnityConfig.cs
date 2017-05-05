using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using DJLNET.Core;
using DJLNET.EntityFramework;
using DJLNET.Repository.Interfaces;
using DJLNET.Repository;
using DJLNET.UnitOfWork;
using DJLNET.ApplicationService.Interfaces;
using DJLNET.ApplicationService;

namespace DJLNET.WebApi.App_Start
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


            container.RegisterType<IDbContext, DJLNETDBContext>(new HierarchicalLifetimeManager());

            container.RegisterType(typeof(IBaseReadOnlyRepository<,>), typeof(BaseReadOnlyRepository<,>), new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRoleRepository, RoleRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPermissionRepository, PermissionRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEntityPermissionRepository, EntityPermissionRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IUnitOfWork, EfUnitOfWork>(new HierarchicalLifetimeManager());

            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRoleService, RoleService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPermissionService, PermissionService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEntityPermissionService, EntityPermissionService>(new HierarchicalLifetimeManager());
        }
    }
}
