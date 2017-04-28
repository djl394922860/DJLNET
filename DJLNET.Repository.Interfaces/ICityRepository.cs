using DJLNET.Model.Entities;

namespace DJLNET.Repository.Interfaces
{
    public interface ICityRepository : IReadOnlyRepository<City, int>
    {
        City GetByName(string name);
    }
}
