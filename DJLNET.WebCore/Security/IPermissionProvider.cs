using DJLNET.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.WebCore.Security
{
    public interface IPermissionProvider
    {
        IEnumerable<Permission> GetPermissions();
    }
}
