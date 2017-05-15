using DJLNET.ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using DJLNET.Repository.Interfaces;
using DJLNET.UnitOfWork;
using System.Linq.Expressions;
using DJLNET.Model.Entities;
using DJLNET.Model;

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

        public bool HasEntityPermission<TEntity>(TEntity entity, Role role) where TEntity : GenericEntity<int>, new()
        {
            string typeName = entity.GetType().Name;
            return _entityPermissionRepository.TableNoTrack().Where(x => x.RoleID == role.ID).Any(x => x.ID == entity.ID && x.EntityName == typeName);
        }

        public bool HasEntityPermission<TEntity>(TEntity entity, User user) where TEntity : GenericEntity<int>, new()
        {
            return user.Roles.Any(role => this.HasEntityPermission<TEntity>(entity, role));
        }
    }
}
