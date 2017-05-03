using DJLNET.ApplicationService.Interfaces;
using DJLNET.ApplicationService;
using DJLNET.EntityFramework;
using DJLNET.Repository;
using DJLNET.Repository.Interfaces;
using DJLNET.UnitOfWork;
using Microsoft.Practices.Unity;
using Xunit;
using DJLNET.Core.Helper;

namespace DJLNET.Test
{
    public class TestService
    {
        private readonly IUnityContainer container;

        private IUserService _userService;

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
        }

        [Fact]
        public void TestAddUser()
        {
            _userService.Add(new Model.Entities.User() { Name = "djlnet11", Password = MD5Helper.GetMD5("123456") });
            System.Console.WriteLine(_userService.Commit());

        }

    }
}
