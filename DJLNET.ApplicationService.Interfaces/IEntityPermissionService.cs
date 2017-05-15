using DJLNET.Model;
using DJLNET.Model.Entities;

namespace DJLNET.ApplicationService.Interfaces
{
    public interface IEntityPermissionService : IBaseReadOnlyService<EntityPermission, int>, IBaseWriteOnlyService<EntityPermission, int>
    {
        bool HasEntityPermission<TEntity>(TEntity entity, User user) where TEntity : GenericEntity<int>, new();
        bool HasEntityPermission<TEntity>(TEntity entity, Role role) where TEntity : GenericEntity<int>, new();
    }
}
