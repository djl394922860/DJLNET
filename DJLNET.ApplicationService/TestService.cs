using DJLNET.ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DJLNET.Model.Models;
using DJLNET.Repository.Interfaces;
using DJLNET.UnitOfWork;

namespace DJLNET.ApplicationService
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IUnitOfWork _unitOfWork;


        public TestService(ITestRepository testRepository, IUnitOfWork unitOfWork)
        {
            this._testRepository = testRepository;
            this._unitOfWork = unitOfWork;
        }

        public bool Add(Test item)
        {
            this._unitOfWork.Add<Test>(item);
            return this._unitOfWork.Commit();
        }

        public bool AddWithTransaction(Test item)
        {
            this._unitOfWork.BeginTransaction();
            this._unitOfWork.Add<Test>(item);
            return this._unitOfWork.Commit();
        }

        public bool Delete(Test item)
        {
            this._unitOfWork.Delete<Test>(item);
            return this._unitOfWork.Commit();
        }

        public Test Get(int id)
        {
            return this._testRepository.Get(id);
        }

        public IEnumerable<Test> GetAll()
        {
            return this._testRepository.GetAll().ToList();
        }

        public bool Update(Test item)
        {
            this._unitOfWork.Update<Test>(item);
            return this._unitOfWork.Commit();
        }
    }
}
