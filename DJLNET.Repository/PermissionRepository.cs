using DJLNET.Repository.Interfaces;
using System.Linq;
using DJLNET.EntityFramework;
using DJLNET.Model.Entities;

namespace DJLNET.Repository
{
    public class PermissionRepository : BaseReadOnlyRepository<Permission, int>, IPermissionRepository
    {
        public PermissionRepository(IDbContext context) : base(context)
        {
        }
    }
}
