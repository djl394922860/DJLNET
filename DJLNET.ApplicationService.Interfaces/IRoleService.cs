using System.Collections.Generic;
using DJLNET.Model.Entities;

namespace DJLNET.ApplicationService.Interfaces
{
    public interface IRoleService : IBaseReadOnlyService<Role, int>, IBaseWriteOnlyService<Role, int>
    {
        void SetPermissions(int roleId, IEnumerable<int> permissionIds);
    }
}
