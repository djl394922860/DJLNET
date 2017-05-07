using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DJLNET.Model.Entities;

namespace DJLNET.WebCore.Mvc
{
    public class AuthorizeProvider : IAuthorizeProvider
    {
        public bool Authorize(string permissionName)
        {
            return this.Authorize(permissionName, WorkConext.CurrentUser);
        }

        public bool Authorize(string permissionName, User user)
        {
            var b = user.Roles.Where(x => x.IsActive && !x.IsDeleted).Any(x => x.Permissions.Any(z => z.Name.Equals(permissionName, StringComparison.CurrentCultureIgnoreCase)));
            return b;
        }
    }
}
