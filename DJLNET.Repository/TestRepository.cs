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
    public class TestRepository : BaseRepository<Test>, ITestRepository
    {
        public TestRepository(IDbContext context) : base(context)
        {
        }

        public Test GetByName(string name)
        {
            return base._entities.FirstOrDefault(x => x.Name == name);
        }
    }
}
