using DJLNET.ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using DJLNET.Repository.Interfaces;
using DJLNET.UnitOfWork;
using System.Linq.Expressions;
using DJLNET.Model.Entities;

namespace DJLNET.ApplicationService
{
    public class EntityPermissionService : BaseService<EntityPermission, int>, IEntityPermissionService
    {
        private readonly IEntityPermissionRepository _entityPermissionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EntityPermissionService(IEntityPermissionRepository entityPermissionRepository, IUnitOfWork unitOfWork) : base(entityPermissionRepository, unitOfWork)
        {
            this._entityPermissionRepository = entityPermissionRepository;
            this._unitOfWork = unitOfWork;
        }

    }
}
