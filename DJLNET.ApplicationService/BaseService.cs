﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DJLNET.ApplicationService.Interfaces;
using DJLNET.Model;
using DJLNET.UnitOfWork;
using DJLNET.Repository.Interfaces;

namespace DJLNET.ApplicationService
{
    public abstract class BaseService<TEntity, TPrimaryKey> :
        IBaseWriteOnlyService<TEntity, TPrimaryKey>,
        IBaseReadOnlyService<TEntity, TPrimaryKey>
        where TEntity : GenericEntity<TPrimaryKey>, new()
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseReadOnlyRepository<TEntity, TPrimaryKey> _baseReadOnlyRepository;
        public BaseService(IBaseReadOnlyRepository<TEntity, TPrimaryKey> baseReadOnlyRepository, IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._baseReadOnlyRepository = baseReadOnlyRepository;
        }

        #region Write
        public void Add(TEntity entity)
        {
            _unitOfWork.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public void AddRang(IEnumerable<TEntity> entities)
        {
            _unitOfWork.AddRang(entities);
            _unitOfWork.SaveChanges();
        }

        public void Commit()
        {
            _unitOfWork.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _unitOfWork.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public void DeleteRang(IEnumerable<TEntity> entities)
        {
            _unitOfWork.DeleteRang(entities);
            _unitOfWork.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _unitOfWork.Update(entity);
            _unitOfWork.SaveChanges();
        }
        #endregion

        #region Read
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _baseReadOnlyRepository.Table().Where(predicate).ToList() ?? new List<TEntity>();
        }

        public TEntity Get(TPrimaryKey key)
        {
            return _baseReadOnlyRepository.GetByKey(key);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _baseReadOnlyRepository.Table().ToList() ?? new List<TEntity>();
        }

        #endregion
    }
}
