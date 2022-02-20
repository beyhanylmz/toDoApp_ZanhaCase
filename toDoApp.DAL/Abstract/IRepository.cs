using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using toDoApp.Entities;

namespace toDoApp.DAL.Abstract
{
    public interface IRepository<TEntity, TKey>
         where TEntity : class, IEntity
    {
        List<TEntity> Get(Expression<Func<TEntity, bool>> exp = null);
        IQueryable<TEntity> GetQuery();
        TEntity Find(TKey id);
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(Guid id);
        bool HardDelete(TEntity entity);
    }
}
