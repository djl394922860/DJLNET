using DJLNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Repository.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        TEntity Get(int id);

        IQueryable<TEntity> GetAll();
    }
}
