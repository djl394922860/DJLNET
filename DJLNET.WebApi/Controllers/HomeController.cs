using DJLNET.ApplicationService.Interfaces;
using DJLNET.Model.Entities;
using DJLNET.WebApi.Common;
using System.Collections.Generic;

namespace DJLNET.WebApi.Controllers
{
    /// <summary>
    /// 主控制器
    /// </summary>
    public class HomeController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public HomeController(IUserService userService, IRoleService roleService)
        {
            this._userService = userService;
            this._roleService = roleService;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<User> GetAllCities()
        {
            return _userService.GetAll();
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Role> GetAllPlatforms()
        {
            return _roleService.GetAll();
        }
    }
}
