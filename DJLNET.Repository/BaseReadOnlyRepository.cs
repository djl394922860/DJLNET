using DJLNET.EntityFramework;
using DJLNET.Model;
using DJLNET.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DJLNET.Core.Paging;
using DJLNET.Core.Extension;
using System.Reflection;

namespace DJLNET.Repository
{
    public class BaseReadOnlyRepository<TEntity, TPrimaryKey> : IBaseReadOnlyRepository<TEntity, TPrimaryKey>
        where TEntity : GenericEntity<TPrimaryKey>, new()
    {
        public readonly IDbContext _context;

        public readonly IQueryable<TEntity> _entities;

        public BaseReadOnlyRepository(IDbContext context)
        {
            this._context = context;
            this._entities = context.Set<TEntity>();
        }

        private class InnerDicKey
        {
            public string TypeFullName { get; set; }
            public string IdValue { get; set; }
        }

        private static Dictionary<InnerDicKey, Expression<Func<TEntity, bool>>> _cacheExpression = new Dictionary<InnerDicKey, Expression<Func<TEntity, bool>>>(new InnerDicKeyCompare());

        private class InnerDicKeyCompare : IEqualityComparer<InnerDicKey>
        {
            public bool Equals(InnerDicKey x, InnerDicKey y)
            {
                if (x == null || y == null)
                    return false;
                if (x.TypeFullName == y.TypeFullName && x.IdValue == y.IdValue)
                    return true;
                return false;
            }

            public int GetHashCode(InnerDicKey obj)
            {
                return obj.TypeFullName.GetHashCode() + obj.IdValue.GetHashCode();
            }
        }

        private Expression<Func<TEntity, bool>> GetPrimaryExpressionCache(TPrimaryKey key)
        {
            var typeName = typeof(TEntity).FullName;
            var idValue = key.ToString();
            var temp = new InnerDicKey { TypeFullName = typeName, IdValue = idValue };
            if (_cacheExpression.ContainsKey(temp))
                return _cacheExpression[temp];
            var param = Expression.Parameter(typeof(TEntity), "x");

            var prop = Expression.Property(param, nameof(GenericEntity<TPrimaryKey>.ID));

            var method = typeof(TPrimaryKey).GetMethods().First(x => x.Name == "Equals" && x.IsFinal == true && x.IsStatic == false
            && x.Attributes == (MethodAttributes.NewSlot | MethodAttributes.Final | MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.Virtual));

            var constant = Expression.Constant(key, typeof(TPrimaryKey));

            var body = Expression.Call(prop, method, constant);

            var exp = Expression.Lambda<Func<TEntity, bool>>(body, param);
            _cacheExpression.Add(temp, exp);
            return exp;
        }

        public virtual TEntity GetByKey(TPrimaryKey key)
        {
            var exp = GetPrimaryExpressionCache(key);
            return _entities.FirstOrDefault(exp);
        }

        public virtual IQueryable<TEntity> Table()
        {
            return _entities;
        }

        public virtual async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await this._context.Set<TEntity>().FindAsync(keyValues).ConfigureAwait(continueOnCapturedContext: false);
        }

        public virtual TEntity Find(params object[] keyValues)
        {
            return this._context.Set<TEntity>().Find(keyValues);
        }

        public virtual async Task<TEntity> GetByKeyAsync(TPrimaryKey key)
        {
            return await Task.Run(() => this._entities.FirstOrDefault(GetPrimaryExpressionCache(key)));
        }

        public virtual IQueryable<TEntity> TableNoTrack()
        {
            return this._context.Set<TEntity>().AsNoTracking();
        }
    }
}
