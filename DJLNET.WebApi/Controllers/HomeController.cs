using DJLNET.ApplicationService.Interfaces;
using DJLNET.Model.Entities;
using DJLNET.Model.Models;
using DJLNET.WebApi.Common;
using System.Collections.Generic;

namespace DJLNET.WebApi.Controllers
{
    /// <summary>
    /// 主控制器
    /// </summary>
    public class HomeController : ApiControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IPlatformService _platformService;

        public HomeController(ICityService cityService, IPlatformService platformService)
        {
            this._cityService = cityService;
            this._platformService = platformService;
        }

        /// <summary>
        /// 获取所有城市
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<City> GetAllCities()
        {
            return _cityService.GetAll();
        }

        /// <summary>
        /// 获取所有平台
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _platformService.GetAll();
        }
    }
}
