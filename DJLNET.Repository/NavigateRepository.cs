using DJLNET.Model.Entities;
using DJLNET.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DJLNET.EntityFramework;

namespace DJLNET.Repository
{
    public class NavigateRepository : BaseReadOnlyRepository<Navigate, int>, INavigateRepository
    {
        public NavigateRepository(IDbContext context) : base(context)
        {
        }
    }
}
