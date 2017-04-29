using DJLNET.Repository.Interfaces;
using System.Linq;
using DJLNET.EntityFramework;
using DJLNET.Model.Entities;

namespace DJLNET.Repository
{
    public class EntityPermissionRepository : BaseReadOnlyRepository<EntityPermission, int>, IEntityPermissionRepository
    {
        public EntityPermissionRepository(IDbContext context) : base(context)
        {
        }
    }
}
