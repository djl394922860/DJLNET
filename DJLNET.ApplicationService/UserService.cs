using DJLNET.ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using DJLNET.Repository.Interfaces;
using DJLNET.UnitOfWork;
using System.Linq.Expressions;
using DJLNET.Model.Entities;
using DJLNET.Core.Helper;
using DJLNET.Core.Cache;

namespace DJLNET.ApplicationService
{
    public class UserService : BaseService<User, int>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheManager _cache;
        private readonly IRoleRepository roleRep;

        public UserService(IUserRepository userRepository, IRoleRepository roleRep, IUnitOfWork unitOfWork, ICacheManager cache) : base(userRepository, unitOfWork)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
            _cache = cache;
            this.roleRep = roleRep;
        }

        public User Login(string name, string pwd)
        {
            var dbPwd = MD5Helper.GetMD5(pwd);
            return _userRepository.Table().FirstOrDefault(x => x.Name == name && x.Password == dbPwd);
        }

        public User GetAuthenticateUser(int id)
        {
            var user = _cache.Get<User>(nameof(GetAuthenticateUser) + "_" + id);
            if (user == null)
            {
                user = _userRepository.GetAuthenticateUser(id);
                _cache.Set(nameof(GetAuthenticateUser) + "_" + id, user, TimeSpan.FromSeconds(30));
            }
            return user;
        }

        public void SetRoleList(int userId, IEnumerable<int> enumerable, string name)
        {
            var user = _userRepository.GetByKey(userId);
            user.Roles.Clear();
            roleRep.Table().Where(x => x.IsActive && !x.IsDeleted).Where(x => enumerable.Contains(x.ID)).ToList().ForEach(x =>
            {
                user.Roles.Add(x);
            });
            user.UpdatedBy = name;
            user.UpdatedTime = DateTime.Now;
            _unitOfWork.Update(user);
            _unitOfWork.SaveChanges();
        }
    }
}
