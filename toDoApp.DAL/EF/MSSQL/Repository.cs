using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using toDoApp.DAL.Abstract;
using toDoApp.Entities;

namespace toDoApp.DAL.EF.MSSQL
{   
    public class Repository<TEntity> : IRepository<TEntity, Guid>
       where TEntity : class, IEntity
    {
        DbContext _db;
        public Repository(DbContext db)
        {
            _db = db;
        }

        public bool Add(TEntity entity)
        {
            //entity.Id = Guid.NewGuid();
            _db.Set<TEntity>().Add(entity);
            return _db.SaveChanges() > 0;
        }

        public bool Delete(Guid id)
        {
            var entity = _db.Set<TEntity>().Find(id);
            entity.IsDeleted = true;
            return Update(entity);
        }

        public TEntity Find(Guid id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> exp = null)
        {
            return exp == null ? _db.Set<TEntity>().ToList() : _db.Set<TEntity>().Where(exp).ToList();
        }
        public TEntity GetOne(Expression<Func<TEntity, bool>> exp = null)
        {
            return exp == null ? _db.Set<TEntity>().SingleOrDefault() : _db.Set<TEntity>().Where(exp).SingleOrDefault();
        }


        public IQueryable<TEntity> GetQuery()
        {
            return _db.Set<TEntity>().Select(x => x);
        }

        public bool HardDelete(TEntity entity)
        {
            try
            {
                _db.Set<TEntity>().Remove(entity);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
