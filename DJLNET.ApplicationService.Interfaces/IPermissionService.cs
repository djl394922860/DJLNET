using DJLNET.Model.Entities;

namespace DJLNET.ApplicationService.Interfaces
{
    public interface IPermissionService : IBaseReadOnlyService<Permission, int>, IBaseWriteOnlyService<Permission, int>
    {
    }
}
