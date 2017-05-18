using DJLNET.ApplicationService.Interfaces;
using DJLNET.ApplicationService;
using DJLNET.EntityFramework;
using DJLNET.Repository;
using DJLNET.Repository.Interfaces;
using DJLNET.UnitOfWork;
using Microsoft.Practices.Unity;
using Xunit;
using DJLNET.Core.Helper;
using System.Collections.Generic;
using DJLNET.Model.Entities;
using System;
using System.Linq;
using System.Reflection;
using DJLNET.Core.Cache;
using DJLNET.Core.Extension;
using AutoMapper;

namespace DJLNET.Test
{
    public class TestService
    {
        private readonly IUnityContainer container;

        private IUserService _userService;

        private IRoleService _roleService;

        private readonly INavigateService _navService;

        public TestService()
        {
            container = new UnityContainer();
            container.RegisterType<IDbContext, DJLNETDBContext>();
            container.RegisterType(typeof(IBaseReadOnlyRepository<,>), typeof(BaseReadOnlyRepository<,>));
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<INavigateRepository, NavigateRepository>();
            container.RegisterType<IPermissionRepository, PermissionRepository>();
            container.RegisterType<IEntityPermissionRepository, EntityPermissionRepository>();
            container.RegisterType<IUnitOfWork, EfUnitOfWork>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<INavigateService, NavigateService>();
            container.RegisterType<IPermissionService, PermissionService>();
            container.RegisterType<IEntityPermissionService, EntityPermissionService>();
            var redisConnnect = System.Configuration.ConfigurationManager.AppSettings["RedisConnection"];
            container.RegisterInstance<ICacheManager>(new RedisCacheManager(redisConnnect));
            _userService = container.Resolve<IUserService>();
            _roleService = container.Resolve<IRoleService>();
            _navService = container.Resolve<INavigateService>();
        }

        [Fact]
        public void TestAddUser()
        {
            _userService.Add(new User() { Name = "djlnet", Password = MD5Helper.GetMD5("123456") });
        }

        [Fact]
        public void TestAddAdministrator()
        {
            _roleService.Add(new Role() { Name = "administrator" });
        }

        [Fact]
        public void TestGetRole()
        {
            var role1 = container.Resolve<IRoleService>().Get(201);

            var role11 = container.Resolve<IRoleService>().Get(201);
            Console.WriteLine();
        }

        [Fact]
        public void TestAddRangRoles()
        {
            var list = new List<Role>();
            for (int i = 1; i <= 100; i++)
            {
                list.Add(new Role { Name = i + "_role", IsActive = true });
            }

            _roleService.AddRang(list);
        }

        [Fact]
        public void TestClearRoles()
        {
            var fk = _roleService.GetAll();
            _roleService.DeleteRang(fk);
        }

        [Fact]
        public void TestGetMethod()
        {
            var methods1 = typeof(int).GetMethods().Where(x => x.Name == "Equals" && x.IsFinal == true && x.IsStatic == false);

            var methods = typeof(string).GetMethods().First(x => x.Name == "Equals" && x.IsFinal == true && x.IsStatic == false
            && x.Attributes == (MethodAttributes.NewSlot | MethodAttributes.Final | MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Virtual));

            Console.WriteLine();
        }

        [Fact]
        public void TestAddUsers()
        {
            var list = new List<User>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new User() { Name = i + "_userName", IsActive = true, Password = "E10ADC3949BA59ABBE56E057F20F883E" });
            }
            _userService.AddRang(list);
            Console.WriteLine("ok");
        }


    }
}
