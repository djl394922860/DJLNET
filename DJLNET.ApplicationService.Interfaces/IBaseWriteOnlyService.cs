using DJLNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.ApplicationService.Interfaces
{
    public interface IBaseWriteOnlyService<TEntity, TPrimaryKey> where TEntity : GenericEntity<TPrimaryKey>, new()
    {
        void Add(TEntity entity);

        void AddRang(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void DeleteRang(IEnumerable<TEntity> entities);

        void Commit();

        void AutoCommit(Action operate);
    }
}
