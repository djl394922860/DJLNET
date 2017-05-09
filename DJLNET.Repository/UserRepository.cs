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

        public User GetAuthenticateUser(int id)
        {
            var user = _context.Set<User>().Find(id);
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            user.Roles.Where(x => !x.IsDeleted).ToList().ForEach(x =>
            {
                this._context.Entry<Role>(x).Collection(z => z.Permissions).Load();
            });
            return user;
        }
    }
}
