using DJLNET.Model.Entities;

namespace DJLNET.ApplicationService.Interfaces
{
    public interface IRoleService : IBaseReadOnlyService<Role, int>, IBaseWriteOnlyService<Role, int>
    {
    }
}
