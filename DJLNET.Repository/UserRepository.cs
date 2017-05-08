using DJLNET.Repository.Interfaces;
using System.Linq;
using DJLNET.EntityFramework;
using DJLNET.Model.Entities;
using System;
using DJLNET.Core.Extension;

namespace DJLNET.Repository
{
    public class UserRepository : BaseReadOnlyRepository<User, int>, IUserRepository
    {
        public UserRepository(IDbContext context) : base(context)
        {
        }
    }
}
