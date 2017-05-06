using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DJLNET.Model.Entities;

namespace DJLNET.WebCore.Security
{
    public class DefaultPermissionrovider : IPermissionProvider
    {
        public IEnumerable<Permission> GetPermissions()
        {
            var permissions = new List<Permission>();

            #region User
            permissions.Add(new Permission { Name = "UserIndex", Category = "用户管理", Description = "查询", CreatedTime = DateTime.Now, CreatedBy = "system", UpdatedTime = DateTime.Now, UpdatedBy = "system", IsDeleted = false });

            permissions.Add(new Permission { Name = "UserAdd", Category = "用户管理", Description = "增加", CreatedTime = DateTime.Now, CreatedBy = "system", UpdatedTime = DateTime.Now, UpdatedBy = "system", IsDeleted = false });

            permissions.Add(new Permission { Name = "UserEdit", Category = "用户管理", Description = "修改", CreatedTime = DateTime.Now, CreatedBy = "system", UpdatedTime = DateTime.Now, UpdatedBy = "system", IsDeleted = false });

            permissions.Add(new Permission { Name = "UserDelete", Category = "用户管理", Description = "删除", CreatedTime = DateTime.Now, CreatedBy = "system", UpdatedTime = DateTime.Now, UpdatedBy = "system", IsDeleted = false });

            permissions.Add(new Permission { Name = "UserAuth", Category = "用户管理", Description = "授权", CreatedTime = DateTime.Now, CreatedBy = "system", UpdatedTime = DateTime.Now, UpdatedBy = "system", IsDeleted = false });
            #endregion


            #region  Role
            permissions.Add(new Permission { Name = "RoleIndex", Category = "角色管理", Description = "查询", CreatedTime = DateTime.Now, CreatedBy = "system", UpdatedTime = DateTime.Now, UpdatedBy = "system", IsDeleted = false });

            permissions.Add(new Permission { Name = "RoleAdd", Category = "角色管理", Description = "增加", CreatedTime = DateTime.Now, CreatedBy = "system", UpdatedTime = DateTime.Now, UpdatedBy = "system", IsDeleted = false });

            permissions.Add(new Permission { Name = "RoleEdit", Category = "角色管理", Description = "修改", CreatedTime = DateTime.Now, CreatedBy = "system", UpdatedTime = DateTime.Now, UpdatedBy = "system", IsDeleted = false });

            permissions.Add(new Permission { Name = "RoleDelete", Category = "角色管理", Description = "删除", CreatedTime = DateTime.Now, CreatedBy = "system", UpdatedTime = DateTime.Now, UpdatedBy = "system", IsDeleted = false });

            permissions.Add(new Permission { Name = "RoleAuth", Category = "角色管理", Description = "授权", CreatedTime = DateTime.Now, CreatedBy = "system", UpdatedTime = DateTime.Now, UpdatedBy = "system", IsDeleted = false });

            #endregion


            return permissions;
        }
    }
}
