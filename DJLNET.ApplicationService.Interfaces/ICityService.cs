using DJLNET.Model.Entities;

namespace DJLNET.ApplicationService.Interfaces
{
    public interface ICityService : IReadOnlyService<City, int>, IWriteOnlyService<City, int>
    {
    }
}
