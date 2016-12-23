using DJLNET.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.ApplicationService.Interfaces
{
    public interface ITestService
    {
        Test Get(int id);

        Task<Test> FindAsync(int id);

        bool Add(Test item);
        bool Update(Test item);
        bool Delete(Test item);

        bool AddWithTransaction(Test item);

        IEnumerable<Test> GetAll();
    }
}
