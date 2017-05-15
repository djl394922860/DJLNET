using DJLNET.ApplicationService.Interfaces;
using DJLNET.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DJLNET.Repository.Interfaces;
using DJLNET.UnitOfWork;

namespace DJLNET.ApplicationService
{
    public class NavigateService : BaseService<Navigate, int>, INavigateService
    {
        public NavigateService(INavigateRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
