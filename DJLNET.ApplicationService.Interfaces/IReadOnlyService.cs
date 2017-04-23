using DJLNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.ApplicationService.Interfaces
{
    public interface IReadOnlyService<TEntity, TPrimaryKey> where TEntity : GenericEntity<TPrimaryKey>, new()
    {
        TEntity Get(TPrimaryKey key);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
