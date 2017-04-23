using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DJLNET.ApplicationService.Interfaces;
using DJLNET.Model;
using DJLNET.UnitOfWork;

namespace DJLNET.ApplicationService
{
    public class WriteOnlyService<TEntity, TPrimaryKey> where TEntity : GenericEntity<TPrimaryKey>, new()
    {
        private readonly IUnitOfWork _unitOfWork;
        public WriteOnlyService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void Add(TEntity entity)
        {
            _unitOfWork.Add(entity);
        }

        public void AddRang(IEnumerable<TEntity> entities)
        {
            _unitOfWork.AddRang(entities);
        }

        public void Commit()
        {
            _unitOfWork.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _unitOfWork.Delete(entity);
        }

        public void DeleteRang(IEnumerable<TEntity> entities)
        {
            _unitOfWork.DeleteRang(entities);
        }

        public void Update(TEntity entity)
        {
            _unitOfWork.Update(entity);
        }
    }
}
