using DJLNET.Model.Entities;

namespace DJLNET.ApplicationService.Interfaces
{
    public interface IEntityPermissionService : IBaseReadOnlyService<EntityPermission, int>, IBaseWriteOnlyService<EntityPermission, int>
    {
    }
}
