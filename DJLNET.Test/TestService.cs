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

namespace DJLNET.Test
{
    public class TestService
    {
        private readonly IUnityContainer container;

        private IUserService _userService;

        private IRoleService _roleService;

        public TestService()
        {
            container = new UnityContainer();
            container.RegisterType<IDbContext, DJLNETDBContext>();
            container.RegisterType(typeof(IBaseReadOnlyRepository<,>), typeof(BaseReadOnlyRepository<,>));
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IUnitOfWork, EfUnitOfWork>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IRoleService, RoleService>();
            _userService = container.Resolve<IUserService>();
            _roleService = container.Resolve<IRoleService>();
        }

        [Fact]
        public void TestAddUser()
        {
            _userService.Add(new Model.Entities.User() { Name = "djlnet11", Password = MD5Helper.GetMD5("123456") });
        }


        [Fact]
        public void TestAddRangRoles()
        {
            var list = new List<Role>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new Role { Name = i + "_role", IsActive = true });
            }

            _roleService.AddRang(list);
        }
    }
}
