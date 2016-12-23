using DJLNET.ApplicationService.Interfaces;
using DJLNET.ApplicationService;
using DJLNET.EntityFramework;
using DJLNET.Repository;
using DJLNET.Repository.Interfaces;
using DJLNET.UnitOfWork;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DJLNET.Test
{
    public class TestService
    {
        private readonly IUnityContainer _container;

        private ITestService _testService;

        public TestService()
        {
            _container = new UnityContainer();
            _container.RegisterType<IDbContext, DJLNETDBContext>();
            _container.RegisterType(typeof(IRepository<>), typeof(BaseRepository<>));
            _container.RegisterType<ITestRepository, TestRepository>();

            _container.RegisterType<IUnitOfWork, EfUnitOfWork>();

            _container.RegisterType<ITestService, DJLNET.ApplicationService.TestService>();

            _testService = _container.Resolve<ITestService>();
        }

        [Fact]
        public void TestAdd()
        {
            var b = _testService.Add(new Model.Models.Test
            {
                Name = DateTime.Now.ToString()
            });
            Assert.True(b);
            Console.WriteLine(b);
        }

        [Fact]
        public async Task TestGetAsync()
        {
            var item = await _testService.FindAsync(8);
            Assert.NotNull(item);
            Console.WriteLine(item.Name);
        }
    }
}
