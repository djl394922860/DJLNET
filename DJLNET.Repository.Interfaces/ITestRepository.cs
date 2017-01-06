using DJLNET.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Repository.Interfaces
{
    public interface ITestRepository : IRepository<Test, int>
    {
        Test GetByName(string name);
    }
}
