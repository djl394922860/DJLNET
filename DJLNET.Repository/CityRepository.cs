using DJLNET.Repository.Interfaces;
using System.Linq;
using DJLNET.EntityFramework;
using DJLNET.Model.Entities;

namespace DJLNET.Repository
{
    public class CityRepository : BaseReadOnlyRepository<City, int>, ICityRepository
    {
        public CityRepository(IDbContext context) : base(context)
        {
        }

        public City GetByName(string name)
        {
            return this._entities.FirstOrDefault(x => x.Name == name);
        }
    }
}
