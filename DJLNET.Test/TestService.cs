﻿using DJLNET.ApplicationService.Interfaces;
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
            container.RegisterType<IPermissionRepository, PermissionRepository>();
            container.RegisterType<IEntityPermissionRepository, EntityPermissionRepository>();
            container.RegisterType<IUnitOfWork, EfUnitOfWork>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IPermissionService, PermissionService>();
            container.RegisterType<IEntityPermissionService, EntityPermissionService>();
            _userService = container.Resolve<IUserService>();
            _roleService = container.Resolve<IRoleService>();
        }

        [Fact]
        public void TestAddUser()
        {
            _userService.Add(new User() { Name = "djlnet11", Password = MD5Helper.GetMD5("123456") });
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
    }
}
