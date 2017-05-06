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
    public class BaseService<TEntity, TPrimaryKey> :
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
        public virtual void Add(TEntity entity)
        {
            _unitOfWork.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual void AddRang(IEnumerable<TEntity> entities)
        {
            _unitOfWork.AddRang(entities);
            _unitOfWork.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _unitOfWork.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual void DeleteRang(IEnumerable<TEntity> entities)
        {
            _unitOfWork.DeleteRang(entities);
            _unitOfWork.SaveChanges();
        }
        public virtual void Update(TEntity entity)
        {
            _unitOfWork.Update(entity);
            _unitOfWork.SaveChanges();
        }
        #endregion

        #region Read
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _baseReadOnlyRepository.TableNoTrack().Where(predicate).ToList() ?? new List<TEntity>();
        }

        public virtual TEntity Get(TPrimaryKey key)
        {
            return _baseReadOnlyRepository.GetByKey(key);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _baseReadOnlyRepository.TableNoTrack().ToList() ?? new List<TEntity>();
        }

        public virtual async Task<TEntity> GetAsync(TPrimaryKey key)
        {
            return await _baseReadOnlyRepository.GetByKeyAsync(key);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() => _baseReadOnlyRepository.TableNoTrack().ToList() ?? new List<TEntity>());
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() => _baseReadOnlyRepository.TableNoTrack().Where(predicate).ToList() ?? new List<TEntity>());
        }

        public virtual IPagedList<TEntity> PagingQuery<TOrder>(Expression<Func<TEntity, bool>> condition, int pageNum, int pageSize, Expression<Func<TEntity, TOrder>> orderby, bool isDesc) where TOrder : struct
        {
            return new PagedList<TEntity, TOrder>(_baseReadOnlyRepository.TableNoTrack(), condition, orderby, pageNum, pageSize, isDesc);
        }

        public virtual async Task<IPagedList<TEntity>> PagingQueryAsync<TOrder>(Expression<Func<TEntity, bool>> condition, int pageNum, int pageSize, Expression<Func<TEntity, TOrder>> orderby, bool isDesc) where TOrder : struct
        {
            return await Task.Run(() => new PagedList<TEntity, TOrder>(_baseReadOnlyRepository.TableNoTrack(), condition, orderby, pageNum, pageSize, isDesc));
        }

        public virtual IPagedList<TEntity> PagingQuery(Expression<Func<TEntity, bool>> condition, int pageNum, int pageSize, string orderbyName, bool isDesc)
        {
            return new PagedDynamicList<TEntity>(this._baseReadOnlyRepository.TableNoTrack(), condition, orderbyName, pageNum, pageSize, isDesc);
        }

        public virtual async Task<IPagedList<TEntity>> PagingQueryAsync(Expression<Func<TEntity, bool>> condition, int pageNum, int pageSize, string orderbyName, bool isDesc)
        {
            return await Task.Run(() => new PagedDynamicList<TEntity>(this._baseReadOnlyRepository.TableNoTrack(), condition, orderbyName, pageNum, pageSize, isDesc));
        }




        #endregion
    }
}
