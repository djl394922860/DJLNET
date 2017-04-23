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
using DJLNET.Model.Models;

namespace DJLNET.Test
{
    public class TestService
    {
        private readonly IUnityContainer container;

        private ICityService _cityService;

        public TestService()
        {
            container = new UnityContainer();


            container.RegisterType<IDbContext, DJLNETDBContext>();

            container.RegisterType(typeof(IReadOnlyRepository<,>), typeof(BaseReadOnlyRepository<,>));

            container.RegisterType<ICityRepository, CityRepository>();
            container.RegisterType<IPlatformRepository, PlatformRepository>();

            container.RegisterType<IUnitOfWork, EfUnitOfWork>();

            container.RegisterType<ICityService, CityService>();
            container.RegisterType<IPlatformService, PlatormService>();

            _cityService = container.Resolve<ICityService>();
        }

        [Fact]
        public void TestAdd()
        {
          
        }

    }
}
