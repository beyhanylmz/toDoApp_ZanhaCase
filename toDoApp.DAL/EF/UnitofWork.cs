using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoApp.DAL.Abstract;
using toDoApp.DAL.EF.MSSQL;

namespace toDoApp.DAL.EF
{    
    public class UnitofWork : IUnitofWork
    {
        DbContext _db;
        DbContextTransaction _tran;
        public UnitofWork(DbContext db)
        {
            _db = db;
        }
        public void BeginTran(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _tran = _db.Database.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            _tran.Commit();
        }

        public void RollBack()
        {
            _tran.Rollback();
        }

        IRepository<TEntity, Guid> IUnitofWork.GetRepository<TEntity>()
        {
            return new Repository<TEntity>(_db);
        }
    }
}
