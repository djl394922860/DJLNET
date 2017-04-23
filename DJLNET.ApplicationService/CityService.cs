using DJLNET.ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DJLNET.Model.Models;
using DJLNET.Repository.Interfaces;
using DJLNET.UnitOfWork;
using System.Linq.Expressions;

namespace DJLNET.ApplicationService
{
    public class CityService : WriteOnlyService<City, int>, ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CityService(ICityRepository cityRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._cityRepository = cityRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<City> Find(Expression<Func<City, bool>> predicate)
        {
            return this._cityRepository.Table().Where(predicate).ToList();
        }

        public City Get(int key)
        {
            return this._cityRepository.GetByKey(key);
        }

        public IEnumerable<City> GetAll()
        {
            return this._cityRepository.Table().ToList();
        }

    }
}
