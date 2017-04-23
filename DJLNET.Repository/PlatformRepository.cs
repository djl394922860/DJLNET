using DJLNET.Model.Models;
using DJLNET.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DJLNET.EntityFramework;

namespace DJLNET.Repository
{
    public class PlatformRepository : BaseReadOnlyRepository<Platform, int>, IPlatformRepository
    {
        public PlatformRepository(IDbContext context) : base(context)
        {
        }
    }
}
