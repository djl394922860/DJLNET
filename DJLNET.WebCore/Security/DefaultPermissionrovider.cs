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

            permissions.Add(new Permission { Name = "UserCreate", Category = "用户管理", Description = "创建", CreatedTime = DateTime.Now, CreatedBy = "system", UpdatedTime = DateTime.Now, UpdatedBy = "system", IsDeleted = false });

            permissions.Add(new Permission { Name = "UserDelete", Category = "用户管理", Description = "删除", CreatedTime = DateTime.Now, CreatedBy = "system", UpdatedTime = DateTime.Now, UpdatedBy = "system", IsDeleted = false });


            return permissions;
        }
    }
}
