﻿using DJLNET.ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using DJLNET.Repository.Interfaces;
using DJLNET.UnitOfWork;
using System.Linq.Expressions;
using DJLNET.Model.Entities;

namespace DJLNET.ApplicationService
{
    public class RoleService : BaseService<Role, int>, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IRoleRepository roleRepository, IPermissionRepository permissionRepository, IUnitOfWork unitOfWork) : base(roleRepository, unitOfWork)
        {
            this._roleRepository = roleRepository;
            this._unitOfWork = unitOfWork;
            _permissionRepository = permissionRepository;
        }

        public void SetPermissions(int roleId, IEnumerable<int> permissionIds)
        {
            var role = _roleRepository.GetByKey(roleId);
            role.Permissions.Clear();
            _permissionRepository.Table().Where(x => permissionIds.Contains(x.ID)).ToList().ForEach(x =>
            {
                role.Permissions.Add(x);
            });
            _unitOfWork.Update(role);
            _unitOfWork.SaveChanges();
        }
    }
}
