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
    public class PlatormService : WriteOnlyService<Platform, int>, IPlatformService
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PlatormService(IPlatformRepository cityRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._platformRepository = cityRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Platform> Find(Expression<Func<Platform, bool>> predicate)
        {
            return this._platformRepository.Table().Where(predicate).ToList();
        }

        public Platform Get(int key)
        {
            return this._platformRepository.GetByKey(key);
        }

        public IEnumerable<Platform> GetAll()
        {
            return this._platformRepository.Table().ToList();
        }

    }
}
