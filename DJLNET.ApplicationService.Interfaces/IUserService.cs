using DJLNET.Model.Entities;

namespace DJLNET.ApplicationService.Interfaces
{
    public interface IUserService : IBaseReadOnlyService<User, int>, IBaseWriteOnlyService<User, int>
    {
    }
}
