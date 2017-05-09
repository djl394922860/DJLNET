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

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, ICacheManager cache) : base(userRepository, unitOfWork)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
            _cache = cache;
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
    }
}
