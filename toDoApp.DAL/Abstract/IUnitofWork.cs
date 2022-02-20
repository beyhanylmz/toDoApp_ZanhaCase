using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoApp.Entities;

namespace toDoApp.DAL.Abstract
{  
    public interface IUnitofWork
    {
        IRepository<TEntity, Guid> GetRepository<TEntity>()
            where TEntity : class, IEntity;
        void BeginTran(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void RollBack();
        void Commit();
    }
}
