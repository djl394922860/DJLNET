using DJLNET.Repository.Interfaces;
using System.Linq;
using DJLNET.EntityFramework;
using DJLNET.Model.Entities;

namespace DJLNET.Repository
{
    public class UserRepository : BaseReadOnlyRepository<User, int>, IUserRepository
    {
        public UserRepository(IDbContext context) : base(context)
        {
        }
    }
}
