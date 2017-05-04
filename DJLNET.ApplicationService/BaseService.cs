using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DJLNET.ApplicationService.Interfaces;
using DJLNET.Model;
using DJLNET.UnitOfWork;
using DJLNET.Repository.Interfaces;
using DJLNET.Core.Paging;

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
        }

        public void AddRang(IEnumerable<TEntity> entities)
        {
            _unitOfWork.AddRang(entities);
        }

        public int Commit()
        {
            return _unitOfWork.SaveChanges();
        }

        public async Task<int> CommitAync()
        {
            return await _unitOfWork.SaveChangesAync();
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



        public async Task<TEntity> GetAsync(TPrimaryKey key)
        {
            return await _baseReadOnlyRepository.GetByKeyAsync(key);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() => _baseReadOnlyRepository.Table().ToList() ?? new List<TEntity>());
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() => _baseReadOnlyRepository.Table().Where(predicate).ToList() ?? new List<TEntity>());
        }

        public IPagedList<TEntity> PagingQuery<TOrder>(Expression<Func<TEntity, bool>> condition, int pageNum, int pageSize, Expression<Func<TEntity, TOrder>> orderby, bool isDesc) where TOrder : struct
        {
            return _baseReadOnlyRepository.PagingQuery(condition, pageNum, pageSize, orderby, isDesc);
        }

        public async Task<IPagedList<TEntity>> PagingQueryAsync<TOrder>(Expression<Func<TEntity, bool>> condition, int pageNum, int pageSize, Expression<Func<TEntity, TOrder>> orderby, bool isDesc) where TOrder : struct
        {
            return await Task.Run(() => _baseReadOnlyRepository.PagingQuery(condition, pageNum, pageSize, orderby, isDesc));
        }
        #endregion
    }
}
