using DJLNET.ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using DJLNET.Repository.Interfaces;
using DJLNET.UnitOfWork;
using System.Linq.Expressions;
using DJLNET.Model.Entities;
using DJLNET.Core.Helper;

namespace DJLNET.ApplicationService
{
    public class UserService : BaseService<User, int>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork) : base(userRepository, unitOfWork)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        public User Login(string name, string pwd)
        {
            var dbPwd = MD5Helper.GetMD5(pwd);
            return _userRepository.Table().FirstOrDefault(x => x.Name == name && x.Password == dbPwd);
        }
    }
}
