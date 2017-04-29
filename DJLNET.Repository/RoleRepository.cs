using DJLNET.Repository.Interfaces;
using DJLNET.EntityFramework;
using DJLNET.Model.Entities;

namespace DJLNET.Repository
{
    public class RoleRepository : BaseReadOnlyRepository<Role, int>, IRoleRepository
    {
        public RoleRepository(IDbContext context) : base(context)
        {
        }
    }
}
