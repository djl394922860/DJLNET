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
        private readonly IPermissionService _permissionService;

        public HomeController(IUserService userService, IRoleService roleService, IPermissionService permissionService)
        {
            this._userService = userService;
            this._roleService = roleService;
            this._permissionService = permissionService;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<User> GetAllUsers()
        {
            return _userService.GetAll();
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Role> GetAllRoles()
        {
            return _roleService.GetAll();
        }

        /// <summary>
        /// 获取所有权限
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Permission> GetAllPermissions()
        {
            return _permissionService.GetAll();
        }
    }
}
