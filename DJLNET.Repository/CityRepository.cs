using DJLNET.Model.Models;
using DJLNET.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DJLNET.EntityFramework;

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
